using Application.DTO;
using Application.Primitives;

namespace Application.Features.Bookcases.Queries.GetBookcases
{
    public sealed record GetBookcasesResponse(Pagination<BookcaseDTO> Bookcases);
}