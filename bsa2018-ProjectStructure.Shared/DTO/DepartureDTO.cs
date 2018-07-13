using System;

namespace bsa2018_ProjectStructure.Shared.DTO
{
    public class DepartureDTO
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public int FlightNumber { get; set; }
        public int IdCrew { get; set; }
        public int IdAircraft { get; set; }
    }
}
