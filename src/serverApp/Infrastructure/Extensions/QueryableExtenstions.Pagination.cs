using Application.Primitives;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static partial class QueryableExtenstions
{
    public static async Task<Pagination<TDTO>> ToPaginateAsync<T, TDTO>(this IQueryable<T> query, Pagination<TDTO> pagination, CancellationToken cancellationToken)
        where T : class
        where TDTO : class
    {
        Pagination<TDTO> result = new(pagination.Page, pagination.PageSize);

        result.Data = await query.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ProjectToType<TDTO>().ToListAsync(cancellationToken);
        result.Total = await query.CountAsync(cancellationToken);

        return result;
    }
}
