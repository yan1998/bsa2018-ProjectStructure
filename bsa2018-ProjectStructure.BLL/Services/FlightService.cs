using System;
using System.Collections.Generic;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using AutoMapper;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public FlightDTO AddFlight(FlightDTO flight)
        {
            Flight modelFlight = mapper.Map<FlightDTO, Flight>(flight);
            return mapper.Map<Flight,FlightDTO>(unitOfWork.Flights.Create(modelFlight));
        }

        public void DeleteFlight(int id)
        {
            unitOfWork.Flights.Delete(id);
        }

        public List<FlightDTO> GetAllFlights()
        {
            IEnumerable<Flight> flight=unitOfWork.Flights.GetAll();
            return mapper.Map<IEnumerable<Flight>, List<FlightDTO>>(flight);
        }

        public FlightDTO GetFlight(int id)
        {
            Flight flight = unitOfWork.Flights.GetById(id);
            return mapper.Map<Flight,FlightDTO>(flight);
        }

        public FlightDTO UpdateFlight(int id,FlightDTO flight)
        {
            Flight modelFlight = mapper.Map<FlightDTO, Flight>(flight);
            Flight result=unitOfWork.Flights.Update(id, modelFlight);
            return mapper.Map<Flight, FlightDTO>(result);
        }
    }
}
