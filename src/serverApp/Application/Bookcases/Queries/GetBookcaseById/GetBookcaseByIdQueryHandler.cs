using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Mapster;

namespace Application.Bookcases.Queries.GetBookcaseById
{
    public class GetBookcaseByIdQueryHandler(IBookcaseRepository bookcaseRepository) : IQueryHandler<GetBookcaseByIdQuery, GetBookcaseByIdResponse>
    {
        private readonly IBookcaseRepository _bookcaseRepository = bookcaseRepository;

        public async Task<GetBookcaseByIdResponse> Handle(GetBookcaseByIdQuery request, CancellationToken cancellationToken)
        {
            Bookcase bookcase = await _bookcaseRepository.GetByIdAsync(request.BookcaseId, cancellationToken);
            GetBookcaseByIdResponse response = bookcase.Adapt<GetBookcaseByIdResponse>();
            return response;
        }
    }
}
