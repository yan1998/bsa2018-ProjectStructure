using System.Collections.Generic;
using System.Linq;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public class DeparturesRepository : IRepository<Departure>
    {
        protected readonly DataContext context;

        public DeparturesRepository(DataContext context)
        {
            this.context = context;
        }

        public Departure Create(Departure entity)
        {
            entity.Id = context.Departures.Last().Id + 1;
            Flight flight = context.Flights.FirstOrDefault(f => f.Id == entity.IdFlight);
            flight.Departures.Add(entity);
            entity.Flight = flight;
            Aircraft aircraft = context.Aicrafts.FirstOrDefault(a => a.Id == entity.IdAircraft);
            aircraft.Departures.Add(entity);
            entity.Aircraft = aircraft;
            entity.Crew = context.Crews.FirstOrDefault(c => c.Id == entity.IdCrew);
            context.Departures.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Departure departure = GetById(id);
            departure.Flight.Departures.Remove(departure);
            departure.Aircraft.Departures.Remove(departure);
            context.Departures.Remove(departure);
        }

        public IEnumerable<Departure> GetAll()
        {
            return context.Departures.ToList();
        }

        public Departure GetById(int id)
        {
            return context.Departures.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Departure entity)
        {
    
        }
    }
}
