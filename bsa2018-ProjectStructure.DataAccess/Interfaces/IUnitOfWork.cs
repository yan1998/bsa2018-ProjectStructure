using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Aircraft> Aircrafts { get; }
        IRepository<AircraftType> AircraftTypes { get; }
        IRepository<Departure> Departures { get; }
        IRepository<Flight> Flights { get; }
        IRepository<Pilot> Pilots { get; }
        IRepository<Stewardess> Stewardess { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Crew> Crews { get; }

        void SaveChages();
        Task SaveChangesAsync();
    }
}
