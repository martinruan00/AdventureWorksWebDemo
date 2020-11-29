using AdventureWorksWebDemo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Models.Production
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [ColumnMetadata("Name")]
        public string Name { get; set; }
        [ColumnMetadata("ProductNumber")]
        public string ProductNumber { get; set; }
        public bool? MakeFlag { get; set; }
        public bool? FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        [ColumnMetadata("StandardCost")]
        public decimal StandardCost { get; set; }
        [ColumnMetadata("ListPrice")]
        public decimal ListPrice { get; set; }
        [ColumnMetadata("Size")]
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        [ColumnMetadata("Weight")]
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public List<string> Photos { get; set; }
    }
}
