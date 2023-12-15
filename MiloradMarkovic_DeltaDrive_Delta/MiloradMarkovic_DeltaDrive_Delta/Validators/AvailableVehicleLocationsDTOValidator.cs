using FluentValidation;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Validators
{
    public class AvailableVehicleLocationsDTOValidator : AbstractValidator<AvailableVehicleLocationsDTO>
    {
        public AvailableVehicleLocationsDTOValidator()
        {
            RuleFor(x => x.PassengersLocation.Latitude).InclusiveBetween(-90, 90);
            RuleFor(x => x.PassengersLocation.Longitude).InclusiveBetween(-180, 179);
            RuleFor(x => x.DistanceLocation.Latitude).InclusiveBetween(-90, 90);
            RuleFor(x => x.DistanceLocation.Longitude).InclusiveBetween(-180, 179);
        }
    }
}
