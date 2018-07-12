using System;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Aircraft:Entity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan LifeSpan { get; set; }

        public int IdAircraftType { get; set; }
        public AircraftType AircraftType { get; set; }

        public List<Departure> Departures { get; set; }
    }
}
