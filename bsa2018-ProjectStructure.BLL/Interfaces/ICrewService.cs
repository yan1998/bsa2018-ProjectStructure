using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface ICrewService
    {
        CrewDTO AddCrew(CrewDTO crew);
        List<CrewDTO> GetAllCrews();
        CrewDTO GetCrew(int id);
        CrewDTO UpdateCrew(int id, CrewDTO crew);
        void DeleteCrew(int id);
    }
}
