using Application.Abstractions.Messaging;

namespace Application.Shelves.Commands.CreateShelf
{
    public sealed record CreateShelfCommand(ushort Number, ushort CountBook, string Name, Guid BookcaseId) : ICommand<Guid> { }
}