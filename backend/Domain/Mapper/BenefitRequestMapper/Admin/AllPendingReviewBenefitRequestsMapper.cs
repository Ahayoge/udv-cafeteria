using UDV_Benefits.Domain.DTO.BenefitRequest.Admin.AllPendingReview;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitRequestMapper.Admin
{
    public static class AllPendingReviewBenefitRequestsMapper
    {
        public static IEnumerable<BenefitRequestDto> ToDto(this List<BenefitRequest> benefitRequests)
        {
            return benefitRequests.Select(br => 
                new BenefitRequestDto
                {
                    Id = br.Id,
                    Name = br.Benefit.Name,
                    Category = br.Benefit.Category.Name,
                    AppliedWhen = br.AppliedWhen,
                    Employee = new BenefitRequestDto.EmployeeDto
                    {
                        FirstName = br.Employee.FirstName,
                        Patronymic = br.Employee.Patronymic,
                        LastName = br.Employee.LastName
                    }
                }
            );
        }
    }
}
