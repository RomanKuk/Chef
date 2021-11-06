using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chef.DAL.Context;
using Chef.DAL.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Chef.BLL.Services.Abstract
{
    public abstract class BaseCrudService<TEntity, TEntityDto, TEntityCreateDto> : ICrudService<TEntityDto, TEntityCreateDto, int>
            where TEntity : Entity
            where TEntityDto : class
            where TEntityCreateDto : class
    {
        protected readonly ChefContext Context;
        protected readonly IMapper Mapper;

        protected BaseCrudService(ChefContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        /// <summary />
        /// <exception cref="ArgumentNullException">Throws an exception when dto is null</exception>
        public virtual async Task<TEntityDto> AddAsync(TEntityCreateDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            var entity = Mapper.Map<TEntity>(dto);

            var additionResult = await Context.Set<TEntity>().AddAsync(entity);

            await Context.SaveChangesAsync();

            var createdEntity = await Context.Set<TEntity>().FindAsync(additionResult.Entity.Id);

            return Mapper.Map<TEntityDto>(createdEntity);
        }

        /// <summary />
        /// <exception cref="ArgumentException">Throws an exception when doesn't exist entity with id</exception>
        public virtual async Task UpdateAsync(TEntityDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            if (!await ExistAsync(entity.Id))
            {
                throw new ArgumentException(entity.Id.ToString());
            }

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        /// <summary />
        /// <exception cref="ArgumentException">Throws an exception when doesn't exist entity with id</exception>
        public virtual async Task RemoveAsync(int id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);

            if (entity is null)
                throw new ArgumentException(id.ToString());

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        /// <summary />
        /// <exception cref="ArgumentException">Throws an exception when doesn't exist entity with id</exception>
        /// <exception cref="InvalidOperationException">More than one entity have same id</exception>
        /// <returns>Not null entity</returns>
        public virtual async Task<TEntityDto> GetAsync(int id, bool isNoTracking = false)
        {
            var resultEntity = isNoTracking ?
                await Context.Set<TEntity>().AsNoTracking().SingleAsync(entity => entity.Id == id) :
                await Context.Set<TEntity>().FindAsync(id);

            return resultEntity != null ? Mapper.Map<TEntityDto>(resultEntity) : throw new ArgumentException(id.ToString());
        }

        public virtual async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var set = await Context.Set<TEntity>().AsNoTracking().ToListAsync();
            return set.Select(entity => Mapper.Map<TEntityDto>(entity));
        }

        /// <summary/>
        /// <exception cref="InvalidOperationException">More than one entity have same id</exception>
        public virtual async Task<bool> ExistAsync(int id)
        {
            return await Context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(entity => entity.Id == id) != null;
        }

        public virtual void Dispose()
        {
            Context.Dispose();
        }
    }
}
