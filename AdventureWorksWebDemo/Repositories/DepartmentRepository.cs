using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Models;
using AdventureWorksWebDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Repositories
{
    public class DepartmentRepository : BaseRepository<DepartmentModel, Department>
    {
        public DepartmentRepository(AdventureWorks2016Context context) : base(context)
        {
        }

        protected override int GetModelId(DepartmentModel c)
        {
            return c.DepartmentId;
        }

        protected override int GetEntityId(Department e)
        {
            return e.DepartmentId;
        }
    }
}
