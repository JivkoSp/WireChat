using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Data.Repository.Generic
{
    public interface IGenericRepo<TEntity> where TEntity:class
    {
        Task AddAsync([NotNull] TEntity entity);
        Task AddRangeAsync([NotNull] IEnumerable<TEntity> entities);
        EntityEntry<TEntity> Attach([NotNull] TEntity entity);
        ValueTask<TEntity> FindAsync(object[] keyValues);
        EntityEntry<TEntity> Remove([NotNull] TEntity entity);
        void RemoveRange([NotNull] IEnumerable<TEntity> entities);  
        void Update([NotNull] TEntity entity); 
    }
}
