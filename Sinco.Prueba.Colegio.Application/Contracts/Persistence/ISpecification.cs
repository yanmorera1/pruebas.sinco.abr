﻿using Sinco.Prueba.Colegio.Domain.Common;
using System.Linq.Expressions;

namespace Sinco.Prueba.Colegio.Application.Contracts.Persistence
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
