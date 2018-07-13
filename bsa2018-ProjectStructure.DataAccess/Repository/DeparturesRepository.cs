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
            if (departure == null)
                throw new System.Exception("Incorrect id");
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

        public Departure Update(int id, Departure entity)
        {
            Departure departure = GetById(id);
            if (departure == null)
                throw new System.Exception("Incorrect id");
            departure.DepartureTime = entity.DepartureTime;
            departure.IdAircraft = entity.IdAircraft;
            departure.Aircraft = context.Aicrafts.FirstOrDefault(a => a.Id == entity.IdAircraft);
            departure.IdCrew = entity.IdCrew;
            departure.Crew = context.Crews.FirstOrDefault(c => c.Id == entity.IdCrew);
            departure.IdFlight = entity.IdFlight;
            departure.Flight = context.Flights.FirstOrDefault(f => f.Id == entity.IdFlight);
            return departure;
        }
    }
}
