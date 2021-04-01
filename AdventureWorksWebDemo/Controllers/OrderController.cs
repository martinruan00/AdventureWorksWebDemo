using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Generators;
using AdventureWorksWebDemo.Models.Production;
using AdventureWorksWebDemo.Models.Sales;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksWebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : AdventureWorksBaseController<OrderModel>
    {
        private readonly IRepository<OrderModel> repository;

        public OrderController(IRepository<OrderModel> repository, IMetadataGenerator metadataGenerator) : base(metadataGenerator)
        {
            this.repository = repository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetEmployee()
        {
            return await this.repository.GetAllAsync();
        }
    }
}
