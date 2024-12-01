using UDV_Benefits.Domain.DTO.BenefitRequest.Admin.PendingReviewById;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitRequestMapper.Admin
{
    public static class GetDmsBenefitRequestByIdMapper
    {
        public static GetDmsBenefitRequestByIdResponse ToDto<T>(this BenefitRequest benefitRequest)
            where T : GetDmsBenefitRequestByIdResponse
        {
            var employee = benefitRequest.Employee;
            return new GetDmsBenefitRequestByIdResponse
            {
                Id = benefitRequest.Id,
                Category = benefitRequest.Benefit.Category.Name,
                Name = benefitRequest.Benefit.Name,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                LastName = employee.LastName,
                Company = employee.Company.ToString(),
                Department = employee.Department.ToString(),
                Position = employee.Position.ToString(),
                DmsProgram = benefitRequest.DmsProgram.ToString()
            };
        }
    }
}
