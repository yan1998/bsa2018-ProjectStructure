using FluentValidation;
using bsa2018_ProjectStructure.Shared.DTO;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class AircraftTypeValidator:AbstractValidator<AircraftTypeDTO>
    {
        public AircraftTypeValidator()
        {
            RuleFor(at => at.LoadCapacity).GreaterThan(0).WithMessage("Load capacity must be greater than 0");
            RuleFor(at => at.Places).ExclusiveBetween(1, 1200).WithMessage("Places count in aircraft must be 1-1200");
        }
    }
}
