using AutoMapper;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.BLL.Validators;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly AircraftValidator validator;

        public AircraftService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new AircraftValidator();
        }

        public AircraftDTO AddAircraft(AircraftDTO aircraft)
        {
            Validation(aircraft);
            Aircraft modelAircraft = mapper.Map<AircraftDTO, Aircraft>(aircraft);
            return mapper.Map<Aircraft, AircraftDTO>(unitOfWork.Aircrafts.Create(modelAircraft));
        }

        public void DeleteAircraft(int id)
        {
            try
            {
                unitOfWork.Aircrafts.Delete(id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public AircraftDTO GetAircraft(int id)
        {
            Aircraft aircraft = unitOfWork.Aircrafts.GetById(id);
            return mapper.Map<Aircraft, AircraftDTO>(aircraft);
        }

        public List<AircraftDTO> GetAllAircrafts()
        {
            IEnumerable<Aircraft> aircrafts = unitOfWork.Aircrafts.GetAll();
            return mapper.Map<IEnumerable<Aircraft>, List<AircraftDTO>>(aircrafts);
        }

        public AircraftDTO UpdateAircraft(int id, AircraftDTO aircraft)
        {
            try
            {
                Validation(aircraft);
                Aircraft modelAircraft = mapper.Map<AircraftDTO, Aircraft>(aircraft);
                Aircraft result = unitOfWork.Aircrafts.Update(id, modelAircraft);
                return mapper.Map<Aircraft, AircraftDTO>(result);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void Validation(AircraftDTO aircraft)
        {
            var validationResult = validator.Validate(aircraft);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
