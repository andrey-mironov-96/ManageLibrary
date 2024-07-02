using Domain.Entities;
using Domain.Primitives;

namespace Domain.Abstractions;
public interface IBookcaseRepository : IBaseRepository<Bookcase>
{
    Task<Pagination<Bookcase>> GetBookcasesAsync(Pagination<Bookcase> pagination, CancellationToken cancellationToken);
}