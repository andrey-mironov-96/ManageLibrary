namespace Application.Features.Books.Commands.CreateBook;

public sealed record CreateBookRequest(string Name, int Pages, string Author);
