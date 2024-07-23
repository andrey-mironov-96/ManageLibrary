using Application.Abstractions.Messaging;

namespace Application.Features.Shelves.Commands.DeleteShelf
{
    public record DeleteShelfCommand (Guid Id) : ICommand<bool>;
}
