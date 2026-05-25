using FluentValidation;
using TaskManager.DTOs.Auth;

namespace TaskManager.MultiTenant.Validators
{

    //   Validators/
    //├── LoginRequestValidator.cs
    //├── RegisterRequestValidator.cs
    //├── VerifyOtpValidator.cs
    //└── ValidationExtensions.cs   ✅ (shared logic)

    //input validation for login request, using FluentValidation library, this is used in the controller layer to validate the incoming request before calling the service layer
    public class LoginRequestValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}

