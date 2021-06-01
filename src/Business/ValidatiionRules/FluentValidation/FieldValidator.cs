using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatiionRules.FluentValidation
{
    public class FieldValidator : AbstractValidator<Field>
    {
        public FieldValidator()
        {
            RuleFor(f => f.FieldName).NotEmpty();
            RuleFor(f => f.FieldName).MinimumLength(3);
            RuleFor(f => f.FieldName).MaximumLength(50);

            RuleFor(f => f.FieldDesc).MaximumLength(255);

            RuleFor(f => f.FieldM2).NotEmpty();
            RuleFor(f => f.FieldM2).GreaterThan(0);
        }
    }
}