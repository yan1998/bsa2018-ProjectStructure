using System.Collections.Generic;
using bsa2018_ProjectStructure.Shared.DTO;

namespace bsa2018_ProjectStructure.BLL.Interfaces
{
    public interface IFlightService
    {
        FlightDTO AddFlight(FlightDTO flight);
        List<FlightDTO> GetAllFlights();
        FlightDTO GetFlight(int id);
        FlightDTO UpdateFlight(int id,FlightDTO flight);
        void DeleteFlight(int id);
    }
}
