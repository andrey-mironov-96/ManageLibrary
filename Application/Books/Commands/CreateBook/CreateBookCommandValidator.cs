using FluentValidation;

namespace Application.Books.Commands.CreateBook;

public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().MinimumLength(1);
        RuleFor(_ => _.Pages).GreaterThan(0);
        RuleFor(_ => _.Author).NotEmpty().MinimumLength(1);
    }
}
