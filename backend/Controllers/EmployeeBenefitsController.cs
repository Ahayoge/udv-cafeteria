using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;
using UDV_Benefits.Domain.Mapper.EmployeeBenefitMapper;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBenefitsController : ControllerBase
    {
        private readonly IEmployeeBenefitService _employeeBenefitService;

        public EmployeeBenefitsController(IEmployeeBenefitService employeeBenefitService)
        {
            _employeeBenefitService = employeeBenefitService;
        }

        [HttpGet("my")]
        [Authorize(Policy = Policy.Worker)]
        public async Task<IActionResult> GetAllActive()
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            var activeBenefits = await _employeeBenefitService.GetActiveEmployeeBenefitsAsync(userId);
            var activeBenefitsDto = activeBenefits.ToDto();
            return Ok(activeBenefitsDto);
        }
    }
}
