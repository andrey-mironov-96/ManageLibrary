using Application.Abstractions.Messaging;

namespace Application.Bookcases.Commands.CreateBookcase
{
    public sealed record CreateBookcaseCommand(ushort Number, string Name, uint MaxSizeShelve) : ICommand<Guid>;
}