using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class DataContext
    {
        public List<Aircraft> Aicrafts { get; set; }
        public List<AircraftType> AircraftTypes { get; set; }
        public List<Departure> Departures { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Stewardess> Stewardess { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Crew> Crews { get; set; }
    }
}
