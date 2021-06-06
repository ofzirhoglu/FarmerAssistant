using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatiionRules.FluentValidation
{
    public class SaleTypeValidator : AbstractValidator<SaleType>
    {
        public SaleTypeValidator()
        {
            RuleFor(c => c.SaleTypeName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(c => c.SaleTypeDesc)
                .MaximumLength(255);
        }
    }
}