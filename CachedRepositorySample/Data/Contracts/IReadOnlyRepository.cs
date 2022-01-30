using CachedRepositorySample.Models;

namespace CachedRepositorySample.Data.Contracts
{
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> List();

    }
}
