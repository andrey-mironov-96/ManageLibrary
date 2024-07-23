using Application.Abstractions.Messaging;

namespace Application.Features.Books.Queries.GetBookById;

public sealed record GetBookByIdQuery(Guid BookId) : IQuery<BookResponse>;