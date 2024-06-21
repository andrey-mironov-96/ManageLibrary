using Application.Abstractions.Messaging;

namespace Application.Bookcases.Commands
{
    public sealed record CreateBookcaseCommand(ushort Number, string Name, uint MaxSizeShelve) : ICommand<Guid>;
}