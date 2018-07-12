
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class AircraftType:Entity
    {
        public Aircraft Aircraft { get; set; }
        public int Places { get; set; }
        public float LoadCapacity { get; set; }
    }
}
