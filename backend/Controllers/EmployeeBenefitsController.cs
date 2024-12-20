﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.EmployeeBenefit.ActiveById;
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
            var employeeId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "employeeId")?.Value);
            var activeBenefits = await _employeeBenefitService.GetActiveEmployeeBenefitsByEmployeeIdAsync(employeeId);
            var activeBenefitsDto = activeBenefits.ToDto();
            return Ok(activeBenefitsDto);
        }

        [HttpGet("{employeeBenefitId:guid}")]
        [Authorize(Policy = Policy.Worker)]
        public async Task<IActionResult> GetActive(Guid employeeBenefitId)
        {
            var activeBenefitResult = await _employeeBenefitService.GetActiveEmployeeBenefitById(employeeBenefitId);
            if (activeBenefitResult.IsFailure)
                return NotFound(new {error = activeBenefitResult.Error!.Description});
            var activeBenefitDto = activeBenefitResult.Value.ToDto<GetActiveEmployeeBenefitResponse>();
            return Ok(activeBenefitDto);
        }
    }
}
