using FluentValidation;

namespace TaskManager.API.Validators
{
    public class TenantIdValidator : AbstractValidator<string>
    {
        public TenantIdValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("TenantId not found in claims.");
        }
    }
}
