﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tti.Estate.Data.Entities;
using Tti.Estate.Data.Specifications;

namespace Tti.Estate.Data.Repositories
{
    public interface IReadRepository<TEntity>
        where TEntity : BaseEntity
    { 
        Task<TEntity> GetAsync(long id);

        Task<TEntity> SingleAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> ListAsync();

        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification);

        Task<int> CountAsync(ISpecification<TEntity> specification);
        Task<bool> AnyAsync(ISpecification<TEntity> specification);
    }
}
