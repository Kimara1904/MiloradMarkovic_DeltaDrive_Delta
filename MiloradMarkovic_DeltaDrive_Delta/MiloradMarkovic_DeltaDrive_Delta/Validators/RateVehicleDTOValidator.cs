using FluentValidation;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Validators
{
    public class RateVehicleDTOValidator : AbstractValidator<RateVehicleDTO>
    {
        public RateVehicleDTOValidator()
        {
            RuleFor(x => x.Rate).NotEmpty().InclusiveBetween(1, 5);
        }
    }
}
