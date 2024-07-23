using Application.DTO;
using Application.Primitives;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IShelfRepository : IBaseRepository<Shelf>
{
    Task<Pagination<ShelfDTO>> GetShelvesByBookcaseIdAsync(Guid bookcaseId, Pagination<ShelfDTO> pagination, CancellationToken cancellationToken);
}
