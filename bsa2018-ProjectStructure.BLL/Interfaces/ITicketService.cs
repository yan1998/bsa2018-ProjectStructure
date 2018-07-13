using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface ITicketService
    {
        TicketDTO AddTicket(TicketDTO ticket);
        List<TicketDTO> GetAllTickets();
        TicketDTO GetTicket(int id);
        TicketDTO UpdateTicket(int id, TicketDTO ticket);
        void DeleteTicket(int id);
    }
}
