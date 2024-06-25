using FluentValidation;

namespace Application.Shelves.Commands.CreateShelf
{
    public class CreateShelfValidator : AbstractValidator<CreateShelfCommand>
    {
        public CreateShelfValidator()
        {
            RuleFor(_ => _.Name).NotEmpty().MinimumLength(3);
            RuleFor(_ => _.Number).NotEmpty().GreaterThan((ushort)0);
            RuleFor(_ => _.CountBook).NotEmpty().GreaterThan((ushort)0);
            RuleFor(_ => _.BookcaseId).NotEmpty();
        }
    }
}