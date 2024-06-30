using Application.Abstractions.Messaging;

namespace Application.Bookcases.Commands.RemoveBookcase
{
    public sealed record RemoveBookcaseCommand(Guid BookcaseId) : ICommand<bool>;
}
