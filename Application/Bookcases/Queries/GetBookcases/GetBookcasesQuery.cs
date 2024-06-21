using Application.Abstractions.Messaging;

namespace Application.Bookcases.Queries.GetBookcases
{
    public sealed record GetBookcasesQuery : IQuery<GetBookcasesResponse>;
}