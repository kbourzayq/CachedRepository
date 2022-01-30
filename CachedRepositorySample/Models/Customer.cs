namespace CachedRepositorySample.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
