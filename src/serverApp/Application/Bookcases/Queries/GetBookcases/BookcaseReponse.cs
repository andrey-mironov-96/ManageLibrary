using Application.DTO;
using Application.Primitives;

namespace Application.Bookcases.Queries.GetBookcases
{
    public sealed record GetBookcasesResponse(Pagination<BookcaseDTO> Bookcases);
}