using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.DTO;
using Application.Primitives;

namespace Application.Features.Shelves.Queries.GetShelvesByBookcaseId;

public sealed class GetShelvesByBookcaseIdQueryHandler(IShelfRepository shelfRepository) : IQueryHandler<GetShelvesByBookcaseIdQuery, GetShelvesByBookcaseIdResponse>
{
    private readonly IShelfRepository _shelfRepository = shelfRepository;

    public async Task<GetShelvesByBookcaseIdResponse> Handle(GetShelvesByBookcaseIdQuery request, CancellationToken cancellationToken)
    {
        Pagination<ShelfDTO> result = await _shelfRepository.GetShelvesByBookcaseIdAsync(request.BookcaseId, request.Shelves, cancellationToken);
        return new GetShelvesByBookcaseIdResponse(result);
    }
}
