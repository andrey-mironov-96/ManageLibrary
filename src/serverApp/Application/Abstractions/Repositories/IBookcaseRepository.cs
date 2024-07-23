using Application.DTO;
using Application.Primitives;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Abstractions.Repositories;
public interface IBookcaseRepository : IBaseRepository<Bookcase>
{
    Task<Pagination<BookcaseDTO>> GetBookcasesAsync(Pagination<BookcaseDTO> pagination, CancellationToken cancellationToken);
}