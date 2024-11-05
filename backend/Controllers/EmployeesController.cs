using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.Employee;
using UDV_Benefits.Domain.Interfaces.EmployeeService;
using UDV_Benefits.Domain.Mapper.EmployeeMapper;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("me")]
        [Authorize(Policy = Policy.Authenticated)]
        public async Task<IActionResult> GetProfile()
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            var profileResult = await _employeeService.GetProfileByUserIdAsync(userId);
            if (profileResult.IsFailure)
            {
                return BadRequest(new { error = profileResult.Error!.Description });
            }
            var profileDto = profileResult.Value.ToDto<GetProfileResponse>();
            return Ok(profileDto);
        }
    }
}
