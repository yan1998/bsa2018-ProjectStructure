using System;
using System.Collections.Generic;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using AutoMapper;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.BLL.Validators;
using System.Linq;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly FlightValidator validator;

        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new FlightValidator();
        }

        public FlightDTO AddFlight(FlightDTO flight)
        {
            Validation(flight);
            Flight modelFlight = mapper.Map<FlightDTO, Flight>(flight);
            return mapper.Map<Flight,FlightDTO>(unitOfWork.Flights.Create(modelFlight));
        }

        public void DeleteFlight(int id)
        {
            try
            {
                unitOfWork.Flights.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
            {
                Validation(flight);
                Flight modelFlight = mapper.Map<FlightDTO, Flight>(flight);
                Flight result = unitOfWork.Flights.Update(id, modelFlight);
                return mapper.Map<Flight, FlightDTO>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validation(FlightDTO flight)
        {
            var validationResult = validator.Validate(flight);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
