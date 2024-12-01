using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.BenefitRequest.Admin.RejectById;
using UDV_Benefits.Domain.DTO.BenefitRequest.Worker.AllBenefitRequests;
using UDV_Benefits.Domain.Interfaces.BenefitRequestService;
using UDV_Benefits.Domain.Mapper.BenefitRequestMapper;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitRequestsController : ControllerBase
    {
        private readonly IBenefitRequestService _benefitRequestService;

        public BenefitRequestsController(IBenefitRequestService benefitRequestService)
        {
            _benefitRequestService = benefitRequestService;
        }

        [HttpGet("my")]
        [Authorize(Policy = Policy.Worker)]
        public async Task<IActionResult> GetAllMyBenefitRequests()
        {
            var employeeId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "employeeId")?.Value);
            var benefitRequests = await _benefitRequestService.GetBenefitRequestsByEmployeeIdAsync(employeeId);
            var benefitRequestsDto = benefitRequests
                .Select(br => br.ToDto<BenefitRequestDto>());
            return Ok(benefitRequestsDto);
        }

        [HttpGet("{benefitRequestId:guid}/reject")]
        [Authorize(Policy = Policy.Admin)]
        public async Task<IActionResult> Reject(Guid benefitRequestId, RejectByIdRequest rejectRequest)
        {
            var rejectResult = await _benefitRequestService
                .RejectBenefitRequestByIdAsync(benefitRequestId, rejectRequest.Reason);
            if (rejectResult.IsFailure)
                return NotFound(new { error = rejectResult.Error!.Description });
            return Ok();
        }

        [HttpGet("{benefitRequestId:guid}/approve")]
        [Authorize(Policy = Policy.Admin)]
        public async Task<IActionResult> Approve(Guid benefitRequestId)
        {
            var approveResult = await _benefitRequestService
                .ApproveBenefitRequestByIdAsync(benefitRequestId);
            if (approveResult.IsFailure)
                return NotFound(new { error = approveResult.Error!.Description });
            return Ok();
        }
    }
}
