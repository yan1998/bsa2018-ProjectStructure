using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface IAircraftService
    {
        AircraftDTO AddAircraft(AircraftDTO flight);
        List<AircraftDTO> GetAllAircrafts();
        AircraftDTO GetAircraft(int id);
        AircraftDTO UpdateAircraft(int id, AircraftDTO aircraft);
        void DeleteAircraft(int id);
    }
}
