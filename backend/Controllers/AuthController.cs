using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.Auth;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces;
using UDV_Benefits.Domain.Mapper;

namespace UDV_Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var user = registerRequest.FromDto();

            var result = await _authService.RegisterAsync(user, registerRequest.Password);
            
            //TODO: pattern-matching
            if (result.IsSuccess)
            {
                return Ok(new { accessToken = result.Value });
            }
            return BadRequest(new { error = result.Error!.Description });
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _authService.LoginAsync(loginRequest.Email, loginRequest.Password);
            if (result.IsSuccess)
                return Ok(new { accessToken = result.Value });
            return BadRequest(new { error = result.Error!.Description });
        } 
    }
}
