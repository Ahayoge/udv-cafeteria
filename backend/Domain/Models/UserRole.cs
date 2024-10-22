using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Domain.Models
{
    public class UserRole
    {
        public Guid Id { get; set; }
        public Role Role { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
