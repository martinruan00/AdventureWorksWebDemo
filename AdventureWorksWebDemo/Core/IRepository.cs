using AdventureWorks.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Core
{
    public interface IRepository<TContract, TEntity>
        where TContract : class
        where TEntity : class, IEntity
    {
        Task<List<TContract>> GetAllAsync();
        Task<TContract> GetAsync(int id);
        Task PostAsync(TContract entity);
        Task PutAsync(TContract entity);
        Task DeleteAsync(int id);
    }
}
