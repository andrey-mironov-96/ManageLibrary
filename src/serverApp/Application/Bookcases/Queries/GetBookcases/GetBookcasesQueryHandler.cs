using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;

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
            IEnumerable<Bookcase> bookcases = await _repository.GetBookcases(cancellationToken);
            return new GetBookcasesResponse(bookcases);
        }
    }
}