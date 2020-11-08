using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Core
{
    public abstract class BaseRepository<TModel, TEntity> : IRepository<TModel>
        where TModel : class
        where TEntity : class, IEntity
    {
        private readonly AdventureWorks2016Context context;
        private IMapper mapper;

        public BaseRepository(AdventureWorks2016Context context)
        {
            this.context = context;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TModel, TEntity>(MemberList.Source);
                cfg.CreateMap<TEntity, TModel>(MemberList.Destination);
            });
            this.ConfigAutoMapper(configuration);
            this.mapper = configuration.CreateMapper();
        }

        public virtual async Task<List<TModel>> GetAllAsync()
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            return entities.Select(mapper.Map<TModel>).ToList();
        }

        public async Task<TModel> GetAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            return mapper.Map<TModel>(entity);
        }

        public virtual async Task PostAsync(TModel contract)
        {
            var mapped = this.mapper.Map<TEntity>(contract);
            context.Set<TEntity>().Add(mapped);
            await context.SaveChangesAsync();
        }

        public virtual async Task PutAsync(TModel contract)
        {
            var dbSet = context.Set<TEntity>();
            var toUpdate = dbSet.FirstOrDefault(e => GetEntityId(e) == GetModelId(contract));
            if (toUpdate != null)
            {
                this.mapper.Map(contract, toUpdate);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            var dbSet = context.Set<TEntity>();
            var toRemove = dbSet.FirstOrDefault(e => GetEntityId(e) == id);
            if (toRemove != null)
            {
                dbSet.Remove(toRemove);
                await context.SaveChangesAsync();
            }
        }

        protected abstract int GetEntityId(TEntity e);

        protected abstract int GetModelId(TModel c);

        protected virtual void ConfigAutoMapper(MapperConfiguration cfg)
        {

        }
    }
}
