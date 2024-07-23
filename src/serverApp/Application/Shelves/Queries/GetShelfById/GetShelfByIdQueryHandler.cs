using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;

namespace Application.Shelves.Queries.GetShelfById
{
    public sealed class GetShelfByIdQueryHandler(IShelfRepository shelfRepository) : IQueryHandler<GetShelfByIdQuery, GetShelfByIdResponse>
    {
        private readonly IShelfRepository _shelfRepository = shelfRepository;

        public async Task<GetShelfByIdResponse> Handle(GetShelfByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _shelfRepository.GetByIdAsync(request.Id, cancellationToken);
            return new GetShelfByIdResponse(result.Id, result.Number, result.CountBooks, result.Name, result.BookcaseId);
        }
    }
}