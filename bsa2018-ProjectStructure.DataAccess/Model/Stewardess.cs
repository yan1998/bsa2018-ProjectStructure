using System;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Stewardess:Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public List<Crew> Crews { get; set; }
    }
}
