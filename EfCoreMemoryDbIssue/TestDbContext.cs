using EfCoreMemoryDbIssue.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;

namespace EfCoreMemoryDbIssue
{
    public class TestDbContext : DbContext
    {
        public DbSet<A> As { get; set; }
        public DbSet<B> Bs { get; set; }
        public DbSet<C> Cs { get; set; }


        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((_, level) => level >= LogLevel.Information, true)
        });

        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        public TestDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(MyLoggerFactory)
                    .UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EfCoreMemoryDbIssue;Integrated Security=SSPI")
                    .EnableSensitiveDataLogging();
            }
        }
    }
}
