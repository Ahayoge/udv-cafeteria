namespace UDV_Benefits.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //TODO: картинка

        public ICollection<Benefit> Benefits { get; set; } = new List<Benefit>();
    }
}
