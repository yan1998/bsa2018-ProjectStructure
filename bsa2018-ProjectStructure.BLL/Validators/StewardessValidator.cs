using bsa2018_ProjectStructure.Shared.DTO;
using FluentValidation;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class StewardessValidator:AbstractValidator<StewardessDTO>
    {
        public StewardessValidator()
        {
            RuleFor(s => s.Name).NotEmpty().Length(2, 15).WithMessage("Please specify a name");
            RuleFor(s => s.Surname).NotEmpty().Length(2, 20).WithMessage("Please specify a surname");
        }
    }
}
