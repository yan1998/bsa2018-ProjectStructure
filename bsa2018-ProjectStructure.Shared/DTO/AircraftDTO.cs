using System;

namespace bsa2018_ProjectStructure.Shared.DTO
{
    public class AircraftDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan LifeSpan { get; set; }
        public int IdAircraftType { get; set; }
    }
}
