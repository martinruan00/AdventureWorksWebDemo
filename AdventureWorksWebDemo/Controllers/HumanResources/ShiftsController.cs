using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models;
using AdventureWorksWebDemo.Models.HumanResources;
using AdventureWorksWebDemo.Generators;

namespace AdventureWorksWebDemo.Controllers.HumanResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : AdventureWorksBaseController<ShiftModel>
    {
        private readonly IRepository<ShiftModel> repository;

        public ShiftsController(IRepository<ShiftModel> repository, IMetadataGenerator metadataGenerator) : base(metadataGenerator)
        {
            this.repository = repository;
        }

        // GET: api/Shifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftModel>>> GetShift()
        {
            return await this.repository.GetAllAsync();
        }

        // GET: api/Shifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftModel>> GetShift(byte id)
        {
            return await this.repository.GetAsync(id);
        }

        // PUT: api/Shifts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift(ShiftModel shift)
        {
            try
            {
                await this.repository.PutAsync(shift);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Shifts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostShift(ShiftModel shift)
        {
            try
            {
                await this.repository.PostAsync(shift);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Shifts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShiftModel>> DeleteShift(byte id)
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
