using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Domain.Common;
using Sinco.Prueba.Colegio.Infrastructure.Persistence;
using Sinco.Prueba.Colegio.Infrastructure.Specification;
using System.Linq.Expressions;

namespace Sinco.Prueba.Colegio.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ColegioDbContext _context;
        public Repository(ColegioDbContext context) => _context = context;
        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T[]> AddRangeAsync(T[] entities)
        {
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public void AddEntity(T entity) => _context.Set<T>().Add(entity);
        public void AddEntityRange(T[] entities) => _context.Set<T>().AddRange(entities);

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void DeleteEntity(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, object>> includeExpression = null,
            bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (includeExpression != null) query = query.Include(includeExpression);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> includeExpression
            ) => await _context.Set<T>().Include(includeExpression).FirstOrDefaultAsync(predicate);

        public async Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> includeExpression,
            string includeString
            )
        {
            var entity = _context.Set<T>();
            if (includeExpression != null)
                entity.Include(includeExpression);

            if (!string.IsNullOrEmpty(includeString))
                entity.Include(includeString);

            return await entity.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            List<Expression<Func<T, object>>> includeExpressions = null,
            List<string> includeStrings = null
            )
        {
            var entity = _context.Set<T>();
            if (includeExpressions != null && includeExpressions.Count > 0)
                foreach (var includeExpression in includeExpressions)
                    entity.Include(includeExpression);

            if (includeStrings != null && includeStrings.Count > 0)
                foreach (var includeString in includeStrings)
                    entity.Include(includeString);

            return await entity.FirstOrDefaultAsync(predicate);
        }


        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> AttachAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public void AttachEntity(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().AnyAsync(predicate);

        public async Task<T> PatchAync(int id, JsonPatchDocument jsonPatch, List<Expression<Func<T, object>>> includeExpressions = null, List<string> includeStrings = null)
        {
            var entity = _context.Set<T>();
            if (includeExpressions != null && includeExpressions.Count > 0)
                foreach (var includeExpression in includeExpressions)
                    entity.Include(includeExpression);

            if (includeStrings != null && includeStrings.Count > 0)
                foreach (var includeString in includeStrings)
                    entity.Include(includeString);

            var _entity = await entity.FirstOrDefaultAsync(x => x.Id == id);

            jsonPatch.ApplyTo(_entity);
            await _context.SaveChangesAsync();
            return _entity;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().CountAsync(predicate);

        public async Task<T> GetByIdWithSpec(ISpecification<T> spec) => await ApplySpecification(spec).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await ApplySpecification(spec).AsNoTracking().ToListAsync();
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<T> GetFirstWithSpec(ISpecification<T> spec, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync();
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public IQueryable<T> ApplySpecification(ISpecification<T> spec) => SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();
    }
}
