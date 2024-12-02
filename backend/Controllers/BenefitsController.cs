using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.Benefit;
using UDV_Benefits.Domain.DTO.Benefit.AddBenefit;
using UDV_Benefits.Domain.DTO.Benefit.AllBenefits;
using UDV_Benefits.Domain.DTO.Benefit.Worker.GetBenefitById;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.BenefitRequestService;
using UDV_Benefits.Domain.Interfaces.BenefitService;
using UDV_Benefits.Domain.Interfaces.CategoryService;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;
using UDV_Benefits.Domain.Interfaces.EmployeeService;
using UDV_Benefits.Domain.Interfaces.UserService;
using UDV_Benefits.Domain.Mapper.BenefitMapper;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitService _benefitService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeBenefitService _employeBenefitService;
        private readonly IBenefitRequestService _benefitRequestService;

        public BenefitsController(IBenefitService benefitService, ICategoryService categoryService, IUserService userService, IEmployeeService employeeService, IEmployeeBenefitService employeBenefitService, IBenefitRequestService benefitRequestService)
        {
            _benefitService = benefitService;
            _categoryService = categoryService;
            _userService = userService;
            _employeeService = employeeService;
            _employeBenefitService = employeBenefitService;
            _benefitRequestService = benefitRequestService;
        }

        [HttpGet]
        [Authorize(Policy = Policy.Authenticated)]
        public async Task<IActionResult> GetAllBenefits()
        {
            var benefits = await _benefitService.GetAllBenefitsAsync();
            var response = benefits.Select(b => b.ToDto<BenefitDto>());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = Policy.Admin)]
        public async Task<IActionResult> AddBenefit(AddBenefitRequest request)
        {
            var categoryResult = await _categoryService.GetCategoryByNameAsync(request.Category);
            if (categoryResult.IsFailure)
            {
                return NotFound(new {error = categoryResult.Error!.Description});
            }

            var benefit = request.FromDto();
            benefit.Category = categoryResult.Value;
            benefit.FormRequired = categoryResult.Value.Name == "ДМС";

            var benefitResult = await _benefitService.AddBenefitAsync(benefit);
            if (benefitResult.IsFailure)
            {
                return Conflict(new {error = benefitResult.Error!.Description}); //TODO: возможно, 409 код лучше
            }
            var benefitDto = benefitResult.Value.ToDto<AddBenefitResponse>();

            return Created(String.Empty, benefitDto);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Policy = Policy.Worker)]
        public async Task<IActionResult> GetBenefitByIdWorker(Guid id)
        {
            var benefitResult = await _benefitService.GetBenefitByIdWorkerAsync(id);
            if (benefitResult.IsFailure) 
            {
                return NotFound(new { error = benefitResult.Error!.Description });
            }

            var benefit = benefitResult.Value;
            var benefitDto = benefit.ToDto<GetBenefitByIdResponse>();

            var employeeId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "employeeId")?.Value);
            var employeeResult = await _employeeService.GetEmployeeById(employeeId);
            var employee = employeeResult.Value;
            benefitDto.ConditionsAreMet = new GetBenefitByIdResponse.ConditionsAreMetDto
            {
                ExperienceYearsRequired = benefit.ExperienceYearsRequired != null 
                ? (DateOnly.FromDateTime(DateTime.Today).Year
                    - employee.StartedWorkWhen.Year) >= benefit.ExperienceYearsRequired
                : null,
                UcoinPrice = benefit.UcoinPrice != null
                ? employee.Ucoins >= benefit.UcoinPrice
                : null,
                OnboardingRequired = benefit.OnboardingRequired
                ? employee.IsOnboarded
                : null
            };
            benefitDto.BenefitRequestExists = await _benefitRequestService.PendingReviewBenefitRequestExists(benefit, employee);
            benefitDto.ActiveEmployeeBenefitExists = await _employeBenefitService.ActiveEmployeeBenefitExists(employee, benefit);

            return Ok(benefitDto);
        }

        [HttpPost("{benefitId:guid}/apply")]
        [Authorize(Policy = Policy.Worker)]
        public async Task<IActionResult> ApplyForBenefit(Guid benefitId, ApplyFormRequest? applyForm)
        {
            var employeeId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "employeeId")?.Value);
            var dmsProgram = applyForm?.FromDto();
            var benefitRequestResult = await _benefitService.ApplyForBenefitAsync(employeeId, benefitId, dmsProgram);
            if (benefitRequestResult.IsFailure)
            {
                if (benefitRequestResult.Error == BenefitErrors.BenefitNotFoundById)
                    return NotFound(new { error = benefitRequestResult.Error!.Description });
                return BadRequest(new { error = benefitRequestResult.Error!.Description });
            }
            return Ok();
        }
    }
}
