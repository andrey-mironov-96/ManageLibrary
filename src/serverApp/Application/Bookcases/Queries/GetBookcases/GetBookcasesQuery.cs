using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Primitives;

namespace Application.Bookcases.Queries.GetBookcases
{
    public sealed record GetBookcasesQuery(Pagination<Bookcase> Data) : IQuery<GetBookcasesResponse>;
}