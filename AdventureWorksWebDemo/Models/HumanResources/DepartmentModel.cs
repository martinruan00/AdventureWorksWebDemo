using AdventureWorksWebDemo.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Models.HumanResources
{
    public class DepartmentModel
    {
        public short DepartmentId { get; set; }
        [ColumnMetadata("Name")]
        public string Name { get; set; }
        [ColumnMetadata("Group name")]
        public string GroupName { get; set; }
    }
}
