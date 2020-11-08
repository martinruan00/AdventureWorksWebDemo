using AdventureWorks.Data;
using AdventureWorksWebDemo.Core;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Models;

namespace AdventureWorksWebDemo.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeModel, Employee>
    {
        public EmployeeRepository(AdventureWorks2016Context context) : base(context)
        {
        }

        protected override int GetModelId(EmployeeModel c)
        {
            return c.BusinessEntityId;
        }

        protected override int GetEntityId(Employee e)
        {
            return e.BusinessEntityId;
        }
    }
}
