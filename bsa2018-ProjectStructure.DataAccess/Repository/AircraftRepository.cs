using bsa2018_ProjectStructure.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public class AircraftRepository : IRepository<Aircraft>
    {
        protected readonly DataContext context;

        public AircraftRepository(DataContext context)
        {
            this.context = context;
        }

        public Aircraft Create(Aircraft entity)
        {
            entity.Id = context.Aicrafts.Last().Id + 1;
            entity.Departures = new List<Departure>();
            context.Aicrafts.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Aircraft aircraft = GetById(id);
            foreach (var departure in aircraft.Departures)
            {
                departure.Flight.Departures.Remove(departure);
                context.Departures.Remove(departure);
            }
            context.AircraftTypes.Remove(aircraft.AircraftType);
            context.Aicrafts.Remove(aircraft);
        }

        public IEnumerable<Aircraft> GetAll()
        {
            return context.Aicrafts.ToList();
        }

        public Aircraft GetById(int id)
        {
            return context.Aicrafts.FirstOrDefault(c => c.Id == id);
        }

        public Aircraft Update(int id,Aircraft entity)
        {
            Aircraft aircraft = GetById(id);
            aircraft.IdAircraftType = entity.IdAircraftType;
            aircraft.AircraftType = context.AircraftTypes.FirstOrDefault(at=>at.Id==entity.IdAircraftType);
            aircraft.LifeSpan = entity.LifeSpan;
            aircraft.ReleaseDate = entity.ReleaseDate;
            aircraft.Name = entity.Name;
            return aircraft;
        }
    }
}
