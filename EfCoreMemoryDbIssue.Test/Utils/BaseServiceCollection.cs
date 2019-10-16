using EfCoreMemoryDbIssue.Test;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace EfCoreMemoryDbIssue.Test
{
    public class BaseServiceCollection
    {
        public static IServiceCollection Create(ITestOutputHelper output)
        {
            return new ServiceCollection()
                .AddDbContext<TestDbContext>(options =>
                {
                    options.UseInMemoryDatabase<TestDbContext>().EnableSensitiveDataLogging();
                })
                .AddLogging(options =>
                {
                    options.AddProvider(new XUnitLoggerProvider(output));
                });
        }
    }
}
