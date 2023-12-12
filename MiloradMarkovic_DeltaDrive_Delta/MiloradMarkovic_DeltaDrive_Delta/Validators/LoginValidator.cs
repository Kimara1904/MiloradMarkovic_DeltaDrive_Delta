using FluentValidation;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(passenger => passenger.Email).NotEmpty();
            RuleFor(passenger => passenger.Password).NotEmpty();
        }
    }
}
