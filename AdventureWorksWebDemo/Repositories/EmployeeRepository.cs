using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeModel, Employee>
    {
        public EmployeeRepository(AdventureWorks2016Context context) : base(context)
        {
        }

        public override Task<List<EmployeeModel>> GetAllAsync()
        {
            return this.context.Employee
                .ProjectTo<EmployeeModel>(this.configuration)
                .ToListAsync();
        }

        protected override void ConfigEntityToModelMapping(IMappingExpression<Employee, EmployeeModel> config)
        {
            config
                .ForMember(m => m.EmployeeId, o => o.MapFrom(m => m.BusinessEntityId))
                .ForMember(m => m.Title, o => o.MapFrom(m => m.BusinessEntity.Title))
                .ForMember(m => m.FirstName, o => o.MapFrom(m => m.BusinessEntity.FirstName))
                .ForMember(m => m.MiddleName, o => o.MapFrom(m => m.BusinessEntity.MiddleName))
                .ForMember(m => m.LastName, o => o.MapFrom(m => m.BusinessEntity.LastName))
                .ForMember(m => m.Suffix, o => o.MapFrom(m => m.BusinessEntity.Suffix))
                .ForMember(m => m.AdditionalContactInfo, o => o.MapFrom(m => m.BusinessEntity.AdditionalContactInfo));
        }

        protected override int GetEntityId(Employee e)
        {
            return e.BusinessEntityId;
        }

        protected override int GetModelId(EmployeeModel c)
        {
            return c.EmployeeId;
        }
    }
}