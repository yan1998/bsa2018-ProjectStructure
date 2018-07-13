using System;

namespace bsa2018_ProjectStructure.Shared.DTO
{
    public class FlightDTO
    {
        public int Number { get; set; }
        public string DeparturePlace { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
