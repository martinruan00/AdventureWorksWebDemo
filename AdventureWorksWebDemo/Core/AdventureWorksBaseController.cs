using AdventureWorksWebDemo.Generators;
using AdventureWorksWebDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Core
{
    public class AdventureWorksBaseController<TModel> : ControllerBase
    {
        private readonly IMetadataGenerator metadataGenerator;

        public AdventureWorksBaseController(IMetadataGenerator metadataGenerator)
        {
            this.metadataGenerator = metadataGenerator;
        }

        [HttpGet("columnmetadata")]
        public IEnumerable<ColumnMetadataModel> GetColumnMetadata()
        {
            return this.metadataGenerator.GetColumnMetadata<TModel>();
        }
    }
}
