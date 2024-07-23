using Application.Abstractions.Messaging;
using Application.DTO;
using Application.Primitives;

namespace Application.Bookcases.Queries.GetBookcases
{
    public sealed record GetBookcasesQuery(Pagination<BookcaseDTO> Data) : IQuery<GetBookcasesResponse>;
}