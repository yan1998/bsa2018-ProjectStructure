using System;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan LifeSpan { get; set; }

        public int IdAircraftType { get; set; }
        public AircraftType AircraftType { get; set; }
    }
}
