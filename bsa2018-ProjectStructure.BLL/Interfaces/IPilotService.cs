using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface IPilotService
    {
        PilotDTO AddPilot(PilotDTO pilot);
        List<PilotDTO> GetAllPilots();
        PilotDTO GetPilot(int id);
        PilotDTO UpdatePilot(int id, PilotDTO pilot);
        void DeletePilot(int id);
    }
}
