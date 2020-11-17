using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models;
using AdventureWorksWebDemo.Models.HumanResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksWebDemo.Controllers.HumanResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<EmployeeModel> repository;

        public EmployeesController(IRepository<EmployeeModel> repository)
        {
            this.repository = repository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployee()
        {
            return await this.repository.GetAllAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployee(int id)
        {
            return await this.repository.GetAsync(id);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(EmployeeModel employee)
        {
            try 
            {
                await this.repository.PutAsync(employee);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostEmployee(EmployeeModel employee)
        {
            try
            {
                await this.repository.PostAsync(employee);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
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
