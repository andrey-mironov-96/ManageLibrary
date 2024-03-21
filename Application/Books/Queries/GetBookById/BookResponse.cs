namespace Application.Books.Queries.GetBookById;

public sealed record BookResponse(Guid Id, string Name, int Pages, string Author);
