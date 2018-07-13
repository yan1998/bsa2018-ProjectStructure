using bsa2018_ProjectStructure.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public class AircraftTypesRepository : IRepository<AircraftType>
    {
        protected readonly DataContext context;

        public AircraftTypesRepository(DataContext context)
        {
            this.context = context;
        }

        public AircraftType Create(AircraftType entity)
        {
            entity.Id = context.AircraftTypes.Last().Id+1;
            context.AircraftTypes.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            AircraftType aircraftType = GetById(id);
            if (aircraftType == null)
                throw new System.Exception("Incorrect id");
            foreach (var departure in aircraftType.Aircraft.Departures)
            {
                departure.Flight.Departures.Remove(departure);
                context.Departures.Remove(departure);
            }
            context.Aicrafts.Remove(aircraftType.Aircraft);
            context.AircraftTypes.Remove(aircraftType);
        }

        public IEnumerable<AircraftType> GetAll()
        {
            return context.AircraftTypes.ToList();
        }

        public AircraftType GetById(int id)
        {
            return context.AircraftTypes.FirstOrDefault(c => c.Id == id);
        }

        public AircraftType Update(int id, AircraftType entity)
        {
            AircraftType aircraftType = GetById(id);
            if (aircraftType == null)
                throw new System.Exception("Incorrect id");
            aircraftType.LoadCapacity = entity.LoadCapacity;
            aircraftType.Places = entity.Places;
            return aircraftType;
        }
    }
}
