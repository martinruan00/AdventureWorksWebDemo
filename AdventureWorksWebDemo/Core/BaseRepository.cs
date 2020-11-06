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
    public abstract class BaseRepository<TContract, TEntity> : IRepository<TContract, TEntity>
        where TContract : class
        where TEntity : class, IEntity
    {
        private readonly AdventureWorks2016Context context;
        private IMapper mapper;

        public BaseRepository(AdventureWorks2016Context context)
        {
            this.context = context;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TContract, TEntity>(MemberList.Source);
                cfg.CreateMap<TEntity, TContract>(MemberList.Destination);
            });
            this.ConfigAutoMapper(configuration);
            this.mapper = configuration.CreateMapper();
        }

        public virtual async Task<List<TContract>> GetAllAsync()
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            return entities.Select(mapper.Map<TContract>).ToList();
        }

        public async Task<TContract> GetAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            return mapper.Map<TContract>(entity);
        }

        public virtual async Task PostAsync(TContract contract)
        {
            var mapped = this.mapper.Map<TEntity>(contract);
            context.Set<TEntity>().Add(mapped);
            await context.SaveChangesAsync();
        }

        public virtual async Task PutAsync(TContract contract)
        {
            var dbSet = context.Set<TEntity>();
            var toUpdate = dbSet.FirstOrDefault(e => GetEntityId(e) == GetContractId(contract));
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

        protected abstract int GetContractId(TContract c);

        protected virtual void ConfigAutoMapper(MapperConfiguration cfg)
        {

        }
    }
}
