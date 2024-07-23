using Application.DTO;
using Application.Primitives;

namespace Application.Shelves.Queries.GetShelvesByBookcaseId;

public sealed record GetShelvesByBookcaseIdResponse(Pagination<ShelfDTO> Shelves);
