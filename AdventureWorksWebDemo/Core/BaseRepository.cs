using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        protected readonly AdventureWorks2016Context context;
        protected readonly IConfigurationProvider configuration;
        private readonly IMapper mapper;

        public BaseRepository(AdventureWorks2016Context context)
        {
            this.context = context;

            this.configuration = new MapperConfiguration(cfg =>
            {
                var modelToEntity = cfg.CreateMap<TModel, TEntity>(MemberList.Source);
                this.ConfigModelToEntityMapping(modelToEntity);

                var entityToModel = cfg.CreateMap<TEntity, TModel>(MemberList.Destination);
                this.ConfigEntityToModelMapping(entityToModel);
            });

            this.mapper = configuration.CreateMapper();
        }

        public virtual Task<List<TModel>> GetAllAsync()
        {
            return context.Set<TEntity>()
                .ProjectTo<TModel>(this.configuration)
                .ToListAsync();
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

        protected virtual void ConfigEntityToModelMapping(IMappingExpression<TEntity, TModel> entityToModel)
        {
        }

        protected virtual void ConfigModelToEntityMapping(IMappingExpression<TModel, TEntity> modelToEntity)
        {
        }
    }
}
