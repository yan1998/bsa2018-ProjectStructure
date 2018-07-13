using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface IDepartureService
    {
        DepartureDTO AddDeparture(DepartureDTO departure);
        List<DepartureDTO> GetAllDepartures();
        DepartureDTO GetDeparture(int id);
        DepartureDTO UpdateDeparture(int id, DepartureDTO departure);
        void DeleteDeparture(int id);
    }
}
