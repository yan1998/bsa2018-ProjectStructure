using System.Collections.Generic;
using System.Linq;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public class TicketsRepository : IRepository<Ticket>
    {
        protected readonly DataContext context;

        public TicketsRepository(DataContext context)
        {
            this.context = context;
        }

        public Ticket Create(Ticket entity)
        {
            entity.Id = context.Tickets.Last().Id + 1;
            Flight flight = context.Flights.FirstOrDefault(f => f.Id == entity.IdFlight);
            flight.Tickets.Add(entity);
            entity.Flight = flight;
            context.Tickets.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Ticket ticket = GetById(id);
            ticket.Flight.Tickets.Remove(ticket);
            context.Tickets.Remove(ticket);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return context.Tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            return context.Tickets.FirstOrDefault(t => t.Id == id);
        }

        public Ticket Update(int id, Ticket entity)
        {
            Ticket ticket = GetById(id);
            ticket.Cost = entity.Cost;
            ticket.IdFlight = entity.IdFlight;
            ticket.Flight = context.Flights.FirstOrDefault(f => f.Id == entity.IdFlight);
            return ticket;
        }
    }
}
