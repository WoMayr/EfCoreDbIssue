using EfCoreMemoryDbIssue.Test;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EfCoreMemoryDbIssue.Test
{

    /// <summary>
    /// Fake database specific extension methods for <see cref="DbContextOptionsBuilder"/>.
    /// </summary>
    public static class FakeDbContextOptionsExtensions
    {
        /// <summary>Unique id for each database context to ensure distinct data</summary>
        private static long id = 0;
        internal static string CreateUniqueDatabaseName<TContext>() where TContext : DbContext => $"{typeof(TContext).Name}_{Interlocked.Increment(ref id)}";
        /// <summary>
        /// Configures the context to connect to a unique in-memory database of the indicated type.
        /// </summary>
        /// <typeparam name="TContext">The type of context to configure.</typeparam>
        /// <param name="optionsBuilder">The builder being used to configure the context.</param>
        /// <returns>The options builder so that further configuration can be chained.</returns>
        public static DbContextOptionsBuilder<TContext> UseInMemoryDatabase<TContext>(this DbContextOptionsBuilder<TContext> optionsBuilder)
            where TContext : DbContext
        {
            var databaseName = CreateUniqueDatabaseName<TContext>();
            return optionsBuilder.UseInMemoryDatabase(databaseName);
        }
        /// <summary>
        /// Configures the context to connect to a unique in-memory database of the indicated type.
        /// </summary>
        /// <typeparam name="TContext">The type of context to configure.</typeparam>
        /// <param name="optionsBuilder">The builder being used to configure the context.</param>
        /// <returns>The options builder so that further configuration can be chained.</returns>
        public static DbContextOptionsBuilder UseInMemoryDatabase<TContext>(this DbContextOptionsBuilder optionsBuilder)
            where TContext : DbContext
        {
            var databaseName = CreateUniqueDatabaseName<TContext>();
            return optionsBuilder.UseInMemoryDatabase(databaseName);
        }

        /// <summary>
        /// Sets the status of all tracked entities to Detached and therefore
        /// Forcing EntityFramework to fetch them from the database
        /// </summary>
        /// <param name="context"></param>
        public static void ClearLocalCache(this DbContext context)
        {
            var changedEntities = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted);
            foreach (var item in changedEntities)
            {
                item.State = EntityState.Detached;
            }
        }
    }
}
