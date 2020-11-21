using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Attributes
{
    public class ColumnMetadataAttribute : Attribute
    {
        public ColumnMetadataAttribute(string header)
        {
            this.Header = header;
        }

        public string Header { get; }
    }
}
