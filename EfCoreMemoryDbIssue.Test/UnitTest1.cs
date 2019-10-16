using EfCoreMemoryDbIssue.Dto;
using EfCoreMemoryDbIssue.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EfCoreMemoryDbIssue.Test
{
    public class Tests
    {
        private readonly IServiceProvider serviceProvider;
        private readonly TestDbContext context;

        public Tests(ITestOutputHelper output)
        {
            serviceProvider = BaseServiceCollection.Create(output)
                .BuildServiceProvider();


            context = serviceProvider.GetRequiredService<TestDbContext>();
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task Test1()
        {
            var a = new A
            {
                PropertyB = new B
                {
                    PropertyCList = new List<C>
                    {
                        new C { SomeText = "TestText" }
                    }
                }
            };
            await context.As.AddAsync(a);
            await context.SaveChangesAsync();

            var myA = await context.As
                .Where(x => x.Id == 1)
                .Select(x => new ADto
                {
                    Id = x.Id,
                    PropertyB = (x.PropertyB == null)
                        ? null
                        : new BDto
                        {
                            Id = x.PropertyB.Id,
                            PropertyCList = x.PropertyB.PropertyCList.Select(
                                y => new CDto {
                                    Id = y.Id,
                                    SomeText = y.SomeText
                                }).ToList()
                        }
                })
                .FirstOrDefaultAsync();

            Assert.Equal("TestText", myA.PropertyB.PropertyCList.First().SomeText);
        }
    }
}