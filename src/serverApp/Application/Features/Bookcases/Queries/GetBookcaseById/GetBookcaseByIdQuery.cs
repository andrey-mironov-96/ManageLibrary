using Application.Abstractions.Messaging;

namespace Application.Features.Bookcases.Queries.GetBookcaseById;

public sealed record GetBookcaseByIdQuery(Guid BookcaseId) : IQuery<GetBookcaseByIdResponse>;
