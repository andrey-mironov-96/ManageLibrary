using Application.Abstractions.Messaging;

namespace Application.Books.Queries.GetBookById;

public sealed record GetBookByIdQuery(Guid bookId) : IQuery<BookResponse>;