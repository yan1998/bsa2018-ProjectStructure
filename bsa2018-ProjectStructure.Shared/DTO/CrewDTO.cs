using System;
using System.Collections.Generic;
using System.Text;

namespace bsa2018_ProjectStructure.Shared.DTO
{
    public class CrewDTO
    {
        public int Id { get; set; }
        public int IdPilot { get; set; }
        public int[] idStewardess { get; set; }
    }
}
