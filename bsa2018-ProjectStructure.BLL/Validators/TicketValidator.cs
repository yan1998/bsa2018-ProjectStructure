using bsa2018_ProjectStructure.Shared.DTO;
using FluentValidation;

namespace bsa2018_ProjectStructure.BLL.Validators
{
    public class TicketValidator:AbstractValidator<TicketDTO>
    {
        public TicketValidator()
        {
            RuleFor(t => t.FlightNumber).GreaterThan(0).WithMessage("Flight number must be greater than 0");
            RuleFor(t => t.Cost).GreaterThan(0).WithMessage("Cost must be greater than 0");
        }
    }
}
