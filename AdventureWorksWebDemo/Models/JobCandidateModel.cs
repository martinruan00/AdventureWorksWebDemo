namespace AdventureWorksWebDemo.Models
{
    public class JobCandidateModel
    {
        public int JobCandidateId { get; set; }
        public int? BusinessEntityId { get; set; }
        public string Resume { get; set; }
    }
}