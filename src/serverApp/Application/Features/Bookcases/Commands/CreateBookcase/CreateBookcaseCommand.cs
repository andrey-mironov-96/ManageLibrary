using Application.Abstractions.Messaging;

namespace Application.Features.Bookcases.Commands.CreateBookcase
{
    public sealed record CreateBookcaseCommand(ushort Number, string Name, uint MaxSizeShelve) : ICommand<Guid>;
}