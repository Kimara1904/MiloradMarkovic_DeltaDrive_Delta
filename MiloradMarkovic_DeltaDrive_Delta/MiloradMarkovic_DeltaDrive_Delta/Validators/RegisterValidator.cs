using FluentValidation;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Email).EmailAddress().NotEmpty();
            RuleFor(user => user.Password).NotEmpty()
                      .Length(8, 30)
                      .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])")
                      .WithMessage("Password must contain at least one uppercase, lowercase letter, digit and special character");
            RuleFor(user => user.FirstName).NotEmpty().MaximumLength(30);
            RuleFor(user => user.LastName).NotEmpty().MaximumLength(30);
            RuleFor(user => user.Birthday).NotEmpty().LessThan(DateTime.Now.AddYears(-18)).WithMessage("Passenger must have 18 years and above");
        }
    }
}
