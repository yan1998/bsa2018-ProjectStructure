using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Repository
{
    public class FlightsRepository : IRepository<Flight>
    {
        protected readonly DataContext context;

        public FlightsRepository(DataContext context)
        {
            this.context = context;
        }

        IEnumerable<Flight> IRepository<Flight>.Get()
        {
            return context.Flights.ToList();
        }

        public Flight GetById(int id)
        {
            return context.Flights.FirstOrDefault(f => f.Id == id);
        }

        public void Create(Flight entity)
        {
            entity.Id = context.Flights.Last().Id + 1;
            entity.Departures = new List<Departure>();
            entity.Tickets = new List<Ticket>();
            context.Flights.Add(entity);
        }

        public void Delete(int id)
        {
            Flight flight = GetById(id);
            context.Tickets.RemoveAll(t=>t.IdFlight==flight.Id);
            context.Departures.RemoveAll(d => d.IdFlight == flight.Id);
            context.Flights.Remove(flight);
        }

        public void Update(Flight entity)
        {

        }
    }
}
