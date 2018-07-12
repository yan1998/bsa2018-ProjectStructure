using System;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Departure
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }

        public int IdCrew { get; set; }
        public Crew Crew { get; set; }

        public int IdAircraft { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
