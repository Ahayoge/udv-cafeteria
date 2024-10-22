namespace UDV_Benefits.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } //TODO: валидация данных
        public string PasswordHash { get; set; }

        public ICollection<UserRole> UsersRoles { get; } = new List<UserRole>();
        public Worker Worker { get; set; }
    }
}
