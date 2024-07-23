using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.DTO;
using Application.Primitives;

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
            Pagination<BookcaseDTO> result = await _repository.GetBookcasesAsync(request.Data, cancellationToken);
            return new GetBookcasesResponse(result);
        }
    }
}