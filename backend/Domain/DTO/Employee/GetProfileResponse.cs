namespace UDV_Benefits.Domain.DTO.Employee
{
    public class GetProfileResponse
    {
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public int Ucoins {  get; set; }
        public int ExperienceYears {  get; set; }
    }
}
