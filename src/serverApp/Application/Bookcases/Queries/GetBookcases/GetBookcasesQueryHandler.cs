using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Primitives;

namespace Application.Bookcases.Queries.GetBookcases
{
    public sealed class GetBookcasesQueryHandler : IQueryHandler<GetBookcasesQuery, GetBookcasesResponse>
    {
        private readonly IBookcaseRepository _repository;

        public GetBookcasesQueryHandler(IBookcaseRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBookcasesResponse> Handle(GetBookcasesQuery request, CancellationToken cancellationToken)
        {
            Pagination<Bookcase> result = await _repository.GetBookcasesAsync(request.Data, cancellationToken);
            return new GetBookcasesResponse(result);
        }
    }
}