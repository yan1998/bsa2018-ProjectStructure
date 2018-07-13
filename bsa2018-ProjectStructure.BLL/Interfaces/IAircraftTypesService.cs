using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface IAircraftTypesService
    {
        AircraftTypeDTO AddAircraftType(AircraftTypeDTO aircraftType);
        List<AircraftTypeDTO> GetAllAircraftTypes();
        AircraftTypeDTO GetAircraftType(int id);
        AircraftTypeDTO UpdateAircraftType(int id, AircraftTypeDTO aircraftType);
        void DeleteAircraftType(int id);
    }
}
