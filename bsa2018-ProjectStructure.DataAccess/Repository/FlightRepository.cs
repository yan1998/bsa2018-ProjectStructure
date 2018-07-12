using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Repository
{
    public class FlightsRepository : IRepository<Flight>
    {
        private DataContext context;

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
            entity.Id = context.Flights.Count + 1;
            context.Flights.Add(entity);
        }

        public void Delete(int id)
        {
            Flight flight = context.Flights.FirstOrDefault(f => f.Id == id);
            context.Tickets.RemoveAll(t=>t.IdFlight==flight.Id);
            context.Departures.RemoveAll(d => d.IdFlight == flight.Id);
            context.Flights.Remove(flight);
        }

        public void Update(Flight entity)
        {
            Flight flight = context.Flights.FirstOrDefault(f=>f.Id==entity.Id);
            flight.ArrivalTime = entity.ArrivalTime;
            flight.DeparturePlace = entity.DeparturePlace;
            flight.DepartureTime = entity.DepartureTime;
            flight.Destination = entity.Destination;
        }
    }
}
