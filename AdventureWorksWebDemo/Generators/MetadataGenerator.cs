using AdventureWorksWebDemo.Attributes;
using AdventureWorksWebDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Generators
{
    public interface IMetadataGenerator
    {
        IEnumerable<ColumnMetadataModel> GetColumnMetadata<TModel>();
    }
    public class MetadataGenerator : IMetadataGenerator
    {
        public IEnumerable<ColumnMetadataModel> GetColumnMetadata<TModel>()
        {
            return typeof(TModel).GetProperties()
                .Select(p => new { Property = p , Attribute = p.GetCustomAttributes(true).OfType<ColumnMetadataAttribute>().FirstOrDefault() })
                .Where(o => o.Attribute != null)
                .Select(o => new ColumnMetadataModel {  Header = o.Attribute.Header, Key = FirstCharacterToLower(o.Property.Name) })
                .ToArray();
        }

        private string FirstCharacterToLower(string s)
        {
            return s.Substring(0, 1).ToLower() + s.Substring(1, s.Length - 1);            
        }
    }
}
