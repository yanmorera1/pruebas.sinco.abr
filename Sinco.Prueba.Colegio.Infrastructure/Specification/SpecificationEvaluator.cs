using Microsoft.EntityFrameworkCore;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Domain.Common;

namespace Sinco.Prueba.Colegio.Infrastructure.Specification
{
    public class SpecificationEvaluator<T> where T : Entity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
                inputQuery = inputQuery.Where(spec.Criteria);

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));
            inputQuery = spec.IncludeStrings.Aggregate(inputQuery, (current, include) => current.Include(include));

            if (spec.OrderBy != null)
                inputQuery = inputQuery.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending != null)
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDescending);

            if (spec.IsPagingEnabled)
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);

            return inputQuery;
        }
    }
}
