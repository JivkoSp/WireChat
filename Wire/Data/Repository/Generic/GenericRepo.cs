using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Data.Repository.Generic
{
    public class GenericRepo<TElement> : IGenericRepo<TElement> where TElement : class
    {
        protected DbContext Context { get; }

        public GenericRepo(DbContext dbContext)
        {
            Context = dbContext;
        }

        public async Task AddAsync([NotNull] TElement entity)
        {
            await Context.Set<TElement>().AddAsync(entity);
        }

        public async Task AddRangeAsync([NotNull] IEnumerable<TElement> entities)
        {
            await Context.Set<TElement>().AddRangeAsync(entities);
        }

        public EntityEntry<TElement> Attach([NotNull] TElement entity)
        {
            return Context.Set<TElement>().Attach(entity);
        }

        public async ValueTask<TElement> FindAsync(object[] keyValues)
        {
            return await Context.Set<TElement>().FindAsync(keyValues);
        }

        public EntityEntry<TElement> Remove([NotNull] TElement entity)
        {
            return Context.Set<TElement>().Remove(entity);
        }

        public void RemoveRange([NotNull] IEnumerable<TElement> entities)
        {
            Context.Set<TElement>().RemoveRange(entities);
        }

        public void Update([NotNull] TElement entity)
        {
            Context.Set<TElement>().Update(entity);
        }
    }
}
