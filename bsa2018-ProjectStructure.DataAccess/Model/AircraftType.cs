﻿
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class AircraftType
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Places { get; set; }
        public float LoadCapacity { get; set; }

        public List<Aircraft> Aircrafts { get; set; }
    }
}
