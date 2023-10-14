﻿using System.Linq.Expressions;

namespace Flow.Infrastructure.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool condition, Expression<Func<T, bool>> predicate)
    {
        return !condition ? queryable : queryable.Where(predicate);
    }
}
