using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.Benefit.AddBenefit;
using UDV_Benefits.Domain.DTO.Benefit.AllBenefits;
using UDV_Benefits.Domain.Interfaces.BenefitService;
using UDV_Benefits.Domain.Interfaces.CategoryService;
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

        public BenefitsController(IBenefitService benefitService, ICategoryService categoryService)
        {
            _benefitService = benefitService;
            _categoryService = categoryService;
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
    }
}
