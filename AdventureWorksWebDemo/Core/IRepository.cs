using AdventureWorks.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Core
{

    public interface IRepository<TModel>
        where TModel : class
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetAsync(int id);
        Task PostAsync(TModel entity);
        Task PutAsync(TModel entity);
        Task DeleteAsync(int id);
    }
}
