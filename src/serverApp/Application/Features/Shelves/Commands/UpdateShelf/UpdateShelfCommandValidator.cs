using FluentValidation;

namespace Application.Features.Shelves.Commands.UpdateShelf
{
    public class UpdateShelfCommandValidator : AbstractValidator<UpdateShelfCommand>
    {
        public UpdateShelfCommandValidator()
        {
            RuleFor(_ => _.Name).NotEmpty().MinimumLength(3);
            RuleFor(_ => _.Number).NotEmpty().GreaterThan((ushort)0);
            RuleFor(_ => _.CountBook).NotEmpty().GreaterThan((ushort)0);
            RuleFor(_ => _.BookcaseId).NotEmpty();

        }
    }
}
