using FluentValidation;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Validators
{
    public class BookVehicleDTOValidator : AbstractValidator<BookVehicleDTO>
    {
        public BookVehicleDTOValidator()
        {
            RuleFor(x => x.Start.Latitude).InclusiveBetween(-90, 90);
            RuleFor(x => x.Start.Longitude).InclusiveBetween(-180, 179);
            RuleFor(x => x.Destination.Latitude).InclusiveBetween(-90, 90);
            RuleFor(x => x.Destination.Longitude).InclusiveBetween(-180, 179);
        }
    }
}
