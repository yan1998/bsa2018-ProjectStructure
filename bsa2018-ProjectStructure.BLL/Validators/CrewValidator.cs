using bsa2018_ProjectStructure.Shared.DTO;
using FluentValidation;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class CrewValidator:AbstractValidator<CrewDTO>
    {
        public CrewValidator()
        {
            RuleFor(c => c.IdPilot).NotEmpty().WithMessage("IdPilot can't be empty!");
            RuleFor(c => c.idStewardess).NotEmpty().WithMessage("idStewardess can't be empty!");
        }
    }
}
