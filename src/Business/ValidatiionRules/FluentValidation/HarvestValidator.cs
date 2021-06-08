using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatiionRules.FluentValidation
{
    public class HarvestValidator : AbstractValidator<Harvest>
    {
        public HarvestValidator()
        {
            RuleFor(x => x.FieldId)
                .NotEmpty();

            RuleFor(x => x.HarvestTypeId)
                .NotEmpty();

            RuleFor(x => x.HarvestQuantity)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.HarvestDate)
                .NotEmpty();

            RuleFor(x => x.HarvestDesc)
                .MaximumLength(255);
        }
    }
}