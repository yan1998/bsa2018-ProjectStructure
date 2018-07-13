using FluentValidation;
using bsa2018_ProjectStructure.Shared.DTO;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class PilotValidator:AbstractValidator<PilotDTO>
    {
        public PilotValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Please specify a name");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Please specify a surname");
            RuleFor(p => p.Experience).GreaterThan(0).LessThan(80).WithMessage("Experience must be 0-80 ages!");
        }
    }
}
