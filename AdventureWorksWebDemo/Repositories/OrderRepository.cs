using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models.Sales;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Repositories
{
    public class OrderRepository : IRepository<OrderModel>
    {
        private readonly AdventureWorks2016Context context;
        private readonly MapperConfiguration mapperConfig;

        public OrderRepository(AdventureWorks2016Context context)
        {
            this.context = context;

            this.mapperConfig = this.CreateMapperConfig();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> GetAllAsync()
        {
            return this.context.SalesOrderHeader
                .ProjectTo<OrderModel>(this.mapperConfig)
                .ToListAsync();
        }

        public Task<OrderModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(OrderModel entity)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(OrderModel entity)
        {
            throw new NotImplementedException();
        }

        private MapperConfiguration CreateMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SalesOrderHeader, OrderModel>(MemberList.Destination)
                    .ForMember(o => o.OrderDetail, m => m.MapFrom(o => o.SalesOrderDetail))
                    ;
                cfg.CreateMap<SalesOrderDetail, OrderDetailModel>(MemberList.Destination)
                    .ForMember(o => o.ProductName, m => m.MapFrom(o => o.SpecialOfferProduct.Product.Name))
                    ;
            });
        }
    }
}
