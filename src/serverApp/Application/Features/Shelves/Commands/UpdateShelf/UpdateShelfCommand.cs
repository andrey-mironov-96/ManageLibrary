using Application.Abstractions.Messaging;
using Application.DTO;

namespace Application.Features.Shelves.Commands.UpdateShelf
{
    public record UpdateShelfCommand(Guid Id, ushort Number, ushort CountBook, string Name, Guid BookcaseId) : ICommand<ShelfDTO>;
}
