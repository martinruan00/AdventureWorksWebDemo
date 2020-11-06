using System;
using System.Collections.Generic;

namespace AdventureWorks.Data.Entities
{
    public partial class JobCandidate : IEntity
    {
        public int JobCandidateId { get; set; }
        public int? BusinessEntityId { get; set; }
        public string Resume { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Employee BusinessEntity { get; set; }
    }
}
