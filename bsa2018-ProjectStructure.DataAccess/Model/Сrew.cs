using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Crew
    {
        public int Id { get; set; }

        public int IdPilot { get; set; }
        public Pilot Pilot { get; set; }

        public int[] IdStewardess { get; set; }
        public List<Stewardess> Stewardess { get; set; }
    }
}
