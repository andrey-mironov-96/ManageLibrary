using Domain.Entities;

namespace Application.Bookcases.Queries.GetBookcases
{
    public sealed record GetBookcasesResponse(IEnumerable<Bookcase> Bookcases);
}