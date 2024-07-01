using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Bookcases.Commands.UpdateBookcase
{
    public sealed record UpdateBookcaseCommand(Guid Id, ushort Number, string Name, uint MaxSizeShelves) : ICommand<Guid>;
}
