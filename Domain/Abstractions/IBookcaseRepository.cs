using Domain.Entities;

namespace Domain.Abstractions;
public interface IBookcaseRepository : IBaseRepository<Bookcase>
{
    Task<IEnumerable<Bookcase>> GetBookcases(CancellationToken cancellationToken);
}