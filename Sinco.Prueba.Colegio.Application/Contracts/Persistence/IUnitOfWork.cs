using Sinco.Prueba.Colegio.Domain.Common;

namespace Sinco.Prueba.Colegio.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        Task<int> Complete();
    }
}
