using System;

namespace AdventureWorksWebDemo.Models.HumanResources
{
    public class ShiftModel
    {
        public byte ShiftId { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
