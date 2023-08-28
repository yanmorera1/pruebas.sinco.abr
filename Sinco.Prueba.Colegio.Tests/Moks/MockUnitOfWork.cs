using Microsoft.EntityFrameworkCore;
using Moq;
using Sinco.Prueba.Colegio.Infrastructure.Persistence;
using Sinco.Prueba.Colegio.Infrastructure.Repositories;

namespace Sinco.Prueba.Colegio.Tests.Moks
{
    public class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<ColegioDbContext>()
                .UseInMemoryDatabase(databaseName: $"ColegioDbContext-{dbContextId}")
                .EnableSensitiveDataLogging()
                .Options;

            var dbContextFake = new ColegioDbContext(options);

            dbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(dbContextFake);

            return mockUnitOfWork;
        }
    }
}
