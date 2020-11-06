using AdventureWorks.Data;
using AdventureWorksWebDemo.Core;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Models;

namespace AdventureWorksWebDemo.Repositories
{
    public class JobCandidateRepository : BaseRepository<JobCandidate, JobCandidate>
    {
        public JobCandidateRepository(AdventureWorks2016Context context) : base(context)
        {
        }

        protected override int GetContractId(JobCandidate c)
        {
            return c.JobCandidateId;
        }

        protected override int GetEntityId(AdventureWorks.Data.Entities.JobCandidate e)
        {
            return e.JobCandidateId;
        }
    }
}
