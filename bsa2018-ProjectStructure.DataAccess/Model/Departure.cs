using System;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Departure:Entity
    {
        public DateTime DepartureTime { get; set; }

        public int IdFlight { get; set; }
        public Flight Flight { get; set; }

        public int IdCrew { get; set; }
        public Crew Crew { get; set; }

        public int IdAircraft { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
