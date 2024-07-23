using Application.Abstractions.Messaging;

namespace Application.Features.Bookcases.Commands.RemoveBookcase
{
    public sealed record RemoveBookcaseCommand(Guid BookcaseId) : ICommand<bool>;
}
