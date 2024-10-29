using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateOnly BirthDate { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public bool IsOnboarded { get; set; }
        public int Ucoins { get; set; }
        public DateOnly StartedWorkWhen { get; set; }

        public User User { get; set; }
    }
}
