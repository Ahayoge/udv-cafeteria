using UDV_Benefits.Domain.DTO.Benefit;
using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Domain.Mapper.BenefitMapper
{
    public static class ApplyMapper
    {
        public static DmsProgram FromDto(this ApplyFormRequest applyFormRequest)
        {
            var dmsProgram = (DmsProgram)Enum.Parse(typeof(DmsProgram), applyFormRequest.DmsProgram, true);
            return dmsProgram;
        }
    }
}
