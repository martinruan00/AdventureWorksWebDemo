using AdventureWorksWebDemo.Attributes;
using System;

namespace AdventureWorksWebDemo.Models.HumanResources
{
    public class ShiftModel
    {
        public byte ShiftId { get; set; }

        [ColumnMetadata("Name")]
        public string Name { get; set; }

        [ColumnMetadata("Start time")]
        public TimeSpan StartTime { get; set; }

        [ColumnMetadata("End time")]
        public TimeSpan EndTime { get; set; }
    }
}
