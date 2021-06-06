using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatiionRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.CompanyName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(c => c.CompanyDesc)
                .MaximumLength(255);
        }
    }
}