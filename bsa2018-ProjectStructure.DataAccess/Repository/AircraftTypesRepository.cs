using bsa2018_ProjectStructure.DataAccess.Model;
using System;
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

        public void Create(AircraftType entity)
        {
            entity.Id = context.AircraftTypes.Last().Id+1;
            context.AircraftTypes.Add(entity);
        }

        public void Delete(int id)
        {
            AircraftType aircraftType = GetById(id);
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

        public void Update(AircraftType entity)
        {
           
        }
    }
}
