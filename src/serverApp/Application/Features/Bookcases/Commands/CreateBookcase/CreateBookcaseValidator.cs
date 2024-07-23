using FluentValidation;

namespace Application.Features.Bookcases.Commands.CreateBookcase
{
    public class CreateBookcaseValidator : AbstractValidator<CreateBookcaseCommand>
    {
        public CreateBookcaseValidator()
        {
            RuleFor(_ => _.Number).NotEmpty().GreaterThan((ushort)0);
            RuleFor(_ => _.Name).NotEmpty().MinimumLength(1);
            RuleFor(_ => _.MaxSizeShelve).GreaterThan((ushort)0);
        }
    }
}