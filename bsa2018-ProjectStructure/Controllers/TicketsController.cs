using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bsa2018_ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        // GET: api/Tickets
        [HttpGet]
        public JsonResult Get()
        {
            return Json(ticketService.GetAllTickets());
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(ticketService.GetTicket(id));
        }
        
        // POST: api/Tickets
        [HttpPost]
        public JsonResult Post([FromBody]TicketDTO ticket)
        {
            return Json(ticketService.AddTicket(ticket));
        }
        
        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]TicketDTO ticket)
        {
            return Json(ticketService.UpdateTicket(id, ticket));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ticketService.DeleteTicket(id);
        }
    }
}
