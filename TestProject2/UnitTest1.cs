using System;

using Xunit;

using AntipaMuseum.Services;
using AntipaMuseum.Data;
using Microsoft.EntityFrameworkCore;
using AntipaMuseum.Core.Models;
using System.Threading.Tasks;

namespace TestProject2
{
    public class UnitTest1
    {
        private readonly IVisitorService sut;

        public UnitTest1()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<AntipaDbContext>().UseInMemoryDatabase("antipadb");
            //var dbContext = new AntipaDbContext(
            //sut = new VisitorService(
        }


        [Fact]
        public async Task VisitorService_GetAll_Returns_Visitors()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AntipaDbContext>().UseInMemoryDatabase("antipadb");
            var existingVisitor = new Visitor { Age = 1 };
            using (var dbContext = new AntipaDbContext(optionsBuilder.Options))
            {
                // Act
                var sut = new VisitorService(dbContext);
                await sut.CreateVisitor(existingVisitor);


                // Assert
                Assert.NotEmpty(await sut.GetAll());
            }
        }
    }
}
