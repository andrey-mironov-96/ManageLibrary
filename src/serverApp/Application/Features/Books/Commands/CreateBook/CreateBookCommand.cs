using Application.Abstractions.Messaging;

namespace Application.Features.Books.Commands.CreateBook;
public sealed record CreateBookCommand(string Name, int Pages, string Author) : ICommand<Guid>;
