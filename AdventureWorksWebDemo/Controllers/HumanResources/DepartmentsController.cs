using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models;
using AdventureWorksWebDemo.Models.HumanResources;
using AdventureWorksWebDemo.Generators;

namespace AdventureWorksWebDemo.Controllers.HumanResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : AdventureWorksBaseController<DepartmentModel>
    {
        private readonly IRepository<DepartmentModel> repository;

        public DepartmentsController(IRepository<DepartmentModel> repository, IMetadataGenerator metadataGenerator) : base(metadataGenerator)
        {
            this.repository = repository;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartment()
        {
            return await this.repository.GetAllAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartment(short id)
        {
            return await this.repository.GetAsync(id);
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(DepartmentModel department)
        {
            try
            {
                await this.repository.PutAsync(department);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostDepartment(DepartmentModel department)
        {
            try
            {
                await this.repository.PostAsync(department);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(short id)
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
