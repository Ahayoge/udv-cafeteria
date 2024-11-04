using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.Benefit.AddBenefit;
using UDV_Benefits.Domain.DTO.Benefit.AllBenefits;
using UDV_Benefits.Domain.DTO.Benefit.Worker.GetBenefitById;
using UDV_Benefits.Domain.Interfaces.BenefitService;
using UDV_Benefits.Domain.Interfaces.CategoryService;
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

        public BenefitsController(IBenefitService benefitService, ICategoryService categoryService, IUserService userService)
        {
            _benefitService = benefitService;
            _categoryService = categoryService;
            _userService = userService;
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

            var benefitDto = benefitResult.Value.ToDto<GetBenefitByIdResponse>();
            return Ok(benefitDto);
        }

        [HttpPost("{benefitId:guid}/apply")]
        [Authorize(Policy = Policy.Worker)]
        public async Task<IActionResult> ApplyForBenefit(Guid benefitId)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            var userResult = await _userService.FindByIdAsync(userId);
            if (userResult.IsFailure)
            {
                return NotFound(new { error = userResult.Error!.Description });
            }
            var benefitResult = await _benefitService.GetBenefitByIdWorkerAsync(benefitId);
            if (benefitResult.IsFailure)
            {
                return NotFound(new { error = benefitResult.Error!.Description });
            }
            var employee = userResult.Value.Employee;
            var benefit = benefitResult.Value;
            var benefitRequestResult = await _benefitService.ApplyForBenefitAsync(employee, benefit);
            if (benefitRequestResult.IsFailure)
            {
                return BadRequest(new { error = benefitRequestResult.Error!.Description });
            }
            return Ok();
        }
    }
}
