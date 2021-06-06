using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatiionRules.FluentValidation
{
    public class HarvestTypeValidator : AbstractValidator<HarvestType>
    {
        public HarvestTypeValidator()
        {
            RuleFor(c => c.HarvestTypeName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(c => c.HarvestTypeDesc)
                .MaximumLength(255);
        }
    }
}