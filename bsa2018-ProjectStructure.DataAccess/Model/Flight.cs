using System;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Flight:Entity
    {
        public string DeparturePlace { get; set; }
        public DateTime DepartureTime{ get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }

        public List<Ticket> Tickets { get; set; }
        public List<Departure> Departures { get; set; }
    }
}
