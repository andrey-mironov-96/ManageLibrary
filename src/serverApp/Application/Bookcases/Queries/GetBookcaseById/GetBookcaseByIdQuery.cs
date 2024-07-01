using Application.Abstractions.Messaging;

namespace Application.Bookcases.Queries.GetBookcaseById;

public sealed record GetBookcaseByIdQuery(Guid BookcaseId) : IQuery<GetBookcaseByIdResponse>;
