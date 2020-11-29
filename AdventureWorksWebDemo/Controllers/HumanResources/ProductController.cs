using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Generators;
using AdventureWorksWebDemo.Models.Production;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksWebDemo.Controllers.HumanResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : AdventureWorksBaseController<ProductModel>
    {
        private readonly IRepository<ProductModel> repository;

        public ProductController(IRepository<ProductModel> repository, IMetadataGenerator metadataGenerator) : base(metadataGenerator)
        {
            this.repository = repository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetEmployee()
        {
            return await this.repository.GetAllAsync();
        }
    }
}
