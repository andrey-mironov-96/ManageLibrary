using Domain.Entities;
using Domain.Primitives;

namespace Application.Bookcases.Queries.GetBookcases
{
    public sealed record GetBookcasesResponse(Pagination<Bookcase> Bookcases);
}