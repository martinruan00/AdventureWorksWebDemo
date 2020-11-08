using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models;

namespace AdventureWorksWebDemo.Controllers.HumanResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidatesController : ControllerBase
    {
        private readonly IRepository<JobCandidateModel> repository;

        public JobCandidatesController(IRepository<JobCandidateModel> repository)
        {
            this.repository = repository;
        }

        // GET: api/JobCandidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobCandidateModel>>> GetJobCandidate()
        {
            return await this.repository.GetAllAsync();
        }

        // GET: api/JobCandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobCandidateModel>> GetJobCandidate(int id)
        {
            return await this.repository.GetAsync(id);
        }

        // PUT: api/JobCandidates/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobCandidate(JobCandidateModel jobCandidate)
        {
            try
            {
                await this.repository.PutAsync(jobCandidate);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/JobCandidates
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostJobCandidate(JobCandidateModel jobCandidate)
        {
            try
            {
                await this.repository.PostAsync(jobCandidate);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/JobCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobCandidate(int id)
        {
            try
            {
                await this.repository.DeleteAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
