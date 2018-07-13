using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Crew:Entity
    {
        public int IdPilot { get; set; }
        public Pilot Pilot { get; set; }

        public List<int> idStewardess { get; set; }
    }
}
