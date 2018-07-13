using System;
using System.Threading.Tasks;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext context;
        private AircraftRepository aircraftRepository;
        private AircraftTypesRepository aircraftTypesRepository;
        private CrewsRepository crewsRepository;
        private DeparturesRepository departuresRepository;
        private FlightsRepository flightsRepository;
        private PilotsRepository pilotsRepository;
        private StewardessRepository stewardessRepository;
        private TicketsRepository ticketsRepository;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public IRepository<Aircraft> Aircrafts
        {
            get
            {
                if (aircraftRepository == null)
                    aircraftRepository = new AircraftRepository(context);
                return aircraftRepository;
            }
        }

        public IRepository<AircraftType> AircraftTypes
        {
            get
            {
                if (aircraftTypesRepository == null)
                    aircraftTypesRepository = new AircraftTypesRepository(context);
                return aircraftTypesRepository;
            }
        }

        public IRepository<Departure> Departures
        {
            get
            {
                if (departuresRepository == null)
                    departuresRepository = new DeparturesRepository(context);
                return departuresRepository;
            }
        }

        public IRepository<Flight> Flights
        {
            get
            {
                if (flightsRepository == null)
                    flightsRepository = new FlightsRepository(context);
                return flightsRepository;
            }
        }

        public IRepository<Pilot> Pilots
        {
            get
            {
                if (pilotsRepository == null)
                    pilotsRepository = new PilotsRepository(context);
                return pilotsRepository;
            }
        }

        public IRepository<Stewardess> Stewardess
        {
            get
            {
                if (stewardessRepository == null)
                    stewardessRepository = new StewardessRepository(context);
                return stewardessRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketsRepository == null)
                    ticketsRepository = new TicketsRepository(context);
                return ticketsRepository;
            }
        }

        public IRepository<Crew> Crews
        {
            get
            {
                if (crewsRepository == null)
                    crewsRepository = new CrewsRepository(context);
                return crewsRepository;
            }
        }

        public void SaveChages()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
