﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Authorize(Policy = Policy.Worker)]
        public async Task<IActionResult> GetAllBenefitRequests()
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            var benefitRequests = await _benefitRequestService.GetWorkerBenefitRequestsAsync(userId);
            var benefitRequestsDto = benefitRequests
                .Select(br => br.ToDto<BenefitRequestDto>());
            return Ok(benefitRequestsDto);
        }
    }
}