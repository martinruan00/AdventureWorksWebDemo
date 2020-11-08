using AdventureWorks.Data;
using AdventureWorksWebDemo.Core;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Models;

namespace AdventureWorksWebDemo.Repositories
{
    public class ShiftRepository : BaseRepository<ShiftModel, Shift>
    {
        public ShiftRepository(AdventureWorks2016Context context) : base(context)
        {
        }

        protected override int GetModelId(ShiftModel c)
        {
            return c.ShiftId;
        }

        protected override int GetEntityId(Shift e)
        {
            return e.ShiftId;
        }
    }
}
