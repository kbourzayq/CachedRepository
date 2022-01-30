using CachedRepositorySample.Data.Contracts;
using CachedRepositorySample.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CachedRepositorySample.Data
{
    public class CachedCustomerRepository : IReadOnlyRepository<Customer>
    {
        private readonly CustomerRepository _repository;
        private readonly IMemoryCache _cache;
        private const string CustomersCacheKey = "Sample::Customers";
        private MemoryCacheEntryOptions cacheOptions;

        
        public CachedCustomerRepository(CustomerRepository repository,
            IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(20));
        }

        public Customer GetById(int id)
        {
            string key = CustomersCacheKey + "-" + id;

            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return _repository.GetById(id);
            });
        }

        public List<Customer> List()
        {
            return _cache.GetOrCreate(CustomersCacheKey, entry =>
            {
                entry.SetOptions(cacheOptions);
                return _repository.List();
            });
        }
    }
}
