using bsa2018_ProjectStructure.Shared.DTO;
using FluentValidation;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class FlightValidator:AbstractValidator<FlightDTO>
    {
        public FlightValidator()
        {
            RuleFor(f=>f.Destination).NotEmpty().WithMessage("Please specify a destination");
            RuleFor(f => f.DeparturePlace).NotEmpty().WithMessage("Please specify a departure place");
            RuleFor(f => f.ArrivalTime).GreaterThan(f => f.DepartureTime).WithMessage("Arrival time must be greater than departure Time");
        }
    }
}
