using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.Benefit.AllBenefits;
using UDV_Benefits.Domain.Interfaces.BenefitService;
using UDV_Benefits.Domain.Mapper;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitService _benefitService;

        public BenefitsController(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        [HttpGet]
        [Authorize(Policy = Policy.Authenticated)]
        public async Task<IActionResult> GetAllBenefits()
        {
            var benefits = await _benefitService.GetAllBenefitsAsync();
            var response = benefits.Select(b => b.ToDto());
            return Ok(response);
        }
    }
}
