using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static partial class QueryableExtenstions
{
    public static async Task<Pagination<T>> ToPaginateAsync<T>(this IQueryable<T> query, Pagination<T> pagination, CancellationToken cancellationToken) where T : class
    {
        pagination.Data = await query.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync(cancellationToken);
        pagination.Total = await query.CountAsync(cancellationToken);

        return pagination;
    }
}
