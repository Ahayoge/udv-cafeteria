namespace UDV_Benefits.Domain.Models
{
    public class StatisticsResult
    {
        public int EmployeeBenefitCountPerBenefit { get; set; }
        public List<Employee> EmployeesWithActiveBenefit { get; set; }
    }
}
