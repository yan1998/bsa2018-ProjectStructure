using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface IStewardessService
    {
        StewardessDTO AddStewardess(StewardessDTO stewardess);
        List<StewardessDTO> GetAllStewardess();
        StewardessDTO GetStewardess(int id);
        StewardessDTO UpdateStewardess(int id, StewardessDTO stewardess);
        void DeleteStewardess(int id);
    }
}
