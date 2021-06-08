using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatiionRules.FluentValidation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x => x.FieldId)
                .NotEmpty();

            RuleFor(x => x.CompanyId)
                .NotEmpty();

            RuleFor(x => x.SaleTypeId)
                .NotEmpty();

            RuleFor(x => x.SaleDate)
                .NotEmpty();

            RuleFor(x => x.SaleQuantity)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.SaleUnitPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.SaleTotalPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.SaleDesc)
                .MaximumLength(255);
        }
    }
}