using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Models.Sales
{
    public class OrderFilterModel
    {
        public byte RevisionNumber { get; set; }
        public DateTime OrderFrom { get; set; }
        public DateTime OrderTo { get; set; }
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
    }
}
