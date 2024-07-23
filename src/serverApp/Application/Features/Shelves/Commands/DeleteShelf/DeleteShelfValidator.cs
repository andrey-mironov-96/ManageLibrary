using FluentValidation;

namespace Application.Features.Shelves.Commands.DeleteShelf;

public sealed class DeleteShelfValidator : AbstractValidator<DeleteShelfCommand>
{
    public DeleteShelfValidator()
    {
        RuleFor(_ => _.Id).NotEmpty();
    }
}
