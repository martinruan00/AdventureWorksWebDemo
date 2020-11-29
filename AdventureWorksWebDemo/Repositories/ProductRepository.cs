using AdventureWorks.Data;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models.Production;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Repositories
{
    public class ProductRepository : IRepository<ProductModel>
    {
        private readonly AdventureWorks2016Context context;
        private readonly MapperConfiguration mapperConfig;

        public ProductRepository(AdventureWorks2016Context context)
        {
            this.context = context;

            this.mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdventureWorks.Data.Entities.Product, ProductModel>(MemberList.Destination)
                    .ForMember(p => p.Photos, m => m.MapFrom(prod => prod.ProductProductPhoto.Select(photo => Convert.ToBase64String(photo.ProductPhoto.LargePhoto))));
            });
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllAsync()
        {
            return this.context.Product
                .ProjectTo<ProductModel>(this.mapperConfig)
                .ToListAsync();
        }

        public Task<ProductModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(ProductModel entity)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(ProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
