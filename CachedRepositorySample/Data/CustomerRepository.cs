using CachedRepositorySample.Data.Contracts;
using CachedRepositorySample.Models;

namespace CachedRepositorySample.Data
{
    public class CustomerRepository : IReadOnlyRepository<Customer>
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Customer GetById(int id)
        {
            return _context.Cutomers.First(x => x.Id == id);
        }

        public List<Customer> List()
        {
            return _context.Cutomers.Take(1000).ToList();
        }
    }
}
