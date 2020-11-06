using System;
using System.Collections.Generic;

namespace AdventureWorks.Data.Entities
{
    public partial class VProductAndDescription : IEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductModel { get; set; }
        public string CultureId { get; set; }
        public string Description { get; set; }
    }
}
