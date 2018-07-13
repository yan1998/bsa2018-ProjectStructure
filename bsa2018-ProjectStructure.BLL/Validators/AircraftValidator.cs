using bsa2018_ProjectStructure.Shared.DTO;
using FluentValidation;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class AircraftValidator:AbstractValidator<AircraftDTO>
    {
        public AircraftValidator()
        {
            RuleFor(a => a.IdAircraftType).NotEmpty().WithMessage("IdAircraftType can't be null!");
            RuleFor(a => a.Name).NotEmpty().Length(2, 15).WithMessage("Aircraft name length must be 2-15");
        }
    }
}
