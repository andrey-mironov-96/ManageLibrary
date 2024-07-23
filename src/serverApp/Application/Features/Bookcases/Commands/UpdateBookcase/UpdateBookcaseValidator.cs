using FluentValidation;

namespace Application.Features.Bookcases.Commands.UpdateBookcase
{
    public sealed class UpdateBookcaseValidator : AbstractValidator<UpdateBookcaseRequest>
    {
        public UpdateBookcaseValidator()
        {
            RuleFor(_ => _.Id).NotEmpty();
            RuleFor(_ => _.Number).NotEmpty().GreaterThan((ushort)0);
            RuleFor(_ => _.Name).NotEmpty().MinimumLength(1);
            RuleFor(_ => _.MaxSizeShelves).NotEmpty().GreaterThan((ushort)0);

        }
    }
}
