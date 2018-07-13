using bsa2018_ProjectStructure.Shared.DTO;
using FluentValidation;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class DepartureValidator:AbstractValidator<DepartureDTO>
    {
        public DepartureValidator()
        {
            RuleFor(d=>d.FlightNumber).GreaterThan(0).WithMessage("Flight number must be greater than 0");
            RuleFor(d=>d.IdAircraft).GreaterThan(0).WithMessage("IdAircraft number must be greater than 0");
            RuleFor(d => d.IdCrew).GreaterThan(0).WithMessage("IdCrew number must be greater than 0");
        }
    }
}
