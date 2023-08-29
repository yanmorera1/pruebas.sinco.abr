using Microsoft.AspNetCore.JsonPatch;
using Sinco.Prueba.Colegio.Domain.Common;
using System.Linq.Expressions;

namespace Sinco.Prueba.Colegio.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, object>> includeExpression = null,
            bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            bool disableTracking = true);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeExpression);
        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> includeExpression,
            string includeString
            );
        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            List<Expression<Func<T, object>>> includeExpressions,
            List<string> includeStrings
            );

        Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate
            );
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T[]> AddRangeAsync(T[] entities);
        Task<T> UpdateAsync(T entity);
        Task<T> PatchAync(int id,
            JsonPatchDocument jsonPatch,
            List<Expression<Func<T, object>>> includeExpressions = null,
            List<string> includeStrings = null);
        Task<T> AttachAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        void AddEntity(T entity);
        void AddEntityRange(T[] entities);
        void UpdateEntity(T entity);
        void AttachEntity(T entity);
        void DeleteEntity(T entity);
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec, bool asNoTracking = false);
        Task<T> GetFirstWithSpec(ISpecification<T> spec, bool asNoTracking = false);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
