using Application.Abstractions.Messaging;
using Application.DTO;
using Application.Primitives;

namespace Application.Shelves.Queries.GetShelvesByBookcaseId;

public sealed record GetShelvesByBookcaseIdQuery(Guid BookcaseId, Pagination<ShelfDTO> Shelves) : IQuery<GetShelvesByBookcaseIdResponse>;
