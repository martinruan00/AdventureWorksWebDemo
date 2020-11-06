using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace AdventureWorks.Data
{
    public class AdventureWorkEntityTypeGenerator : CSharpEntityTypeGenerator
    {
        public AdventureWorkEntityTypeGenerator(ICSharpHelper cSharpHelper)
            : base(cSharpHelper)
        {
        }

        public override string WriteCode(IEntityType entityType, string @namespace, bool useDataAnnotations)
        {
            string code = base.WriteCode(entityType, @namespace, useDataAnnotations);

            var oldString = $"public partial class {entityType.Name}";
            var newString = $"public partial class {entityType.Name} : IEntity";

            return code.Replace(oldString, newString);
        }
    }
}
