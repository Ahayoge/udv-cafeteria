namespace UDV_Benefits.Domain.DTO.Statistics
{
    public class GetStatisticsResponse
    {
        public class EmployeeDto
        {
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
            public string LastName { get; set; }
            public string Department { get; set; }
        }
        public int EmployeeBenefitCountPerBenefit { get; set; }
        public List<EmployeeDto> EmployeesWithActiveBenefit { get; set; }
        public int EmployeesCount { get; set; }
    }
}
