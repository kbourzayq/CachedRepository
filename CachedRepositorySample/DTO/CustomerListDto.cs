using CachedRepositorySample.Models;

namespace CachedRepositorySample.DTO
{
    public class CustomerListDto
    {
        public long ElapsedTimeMilliseconds { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
