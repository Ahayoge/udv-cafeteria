namespace UDV_Benefits.Domain.DTO.Auth
{
    public class RegisterRequest
    {
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password {  get; set; }
        public string BirthDate { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Department{ get; set; }
    }
}
