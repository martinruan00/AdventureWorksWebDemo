using AdventureWorks.Data;
using AdventureWorksWebDemo.Core;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Models;
using AdventureWorksWebDemo.Models.HumanResources;

namespace AdventureWorksWebDemo.Repositories
{
    public class JobCandidateRepository : BaseRepository<JobCandidateModel, JobCandidate>
    {
        public JobCandidateRepository(AdventureWorks2016Context context) : base(context)
        {
        }

        protected override int GetModelId(JobCandidateModel c)
        {
            return c.JobCandidateId;
        }

        protected override int GetEntityId(AdventureWorks.Data.Entities.JobCandidate e)
        {
            return e.JobCandidateId;
        }
    }
}
