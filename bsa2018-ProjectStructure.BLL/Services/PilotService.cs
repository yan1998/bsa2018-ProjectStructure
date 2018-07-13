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
    public class PilotService:IPilotService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PilotValidator validator;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new PilotValidator();
        }

        public PilotDTO AddPilot(PilotDTO pilot)
        {
            Validation(pilot);
            Pilot modelPilot = mapper.Map<PilotDTO, Pilot>(pilot);
            return mapper.Map<Pilot, PilotDTO>(unitOfWork.Pilots.Create(modelPilot));
        }

        public void DeletePilot(int id)
        {
            try
            {
                unitOfWork.Pilots.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PilotDTO> GetAllPilots()
        {
            IEnumerable<Pilot> pilots = unitOfWork.Pilots.GetAll();
            return mapper.Map<IEnumerable<Pilot>, List<PilotDTO>>(pilots);
        }

        public PilotDTO GetPilot(int id)
        {
            Pilot pilot = unitOfWork.Pilots.GetById(id);
            return mapper.Map<Pilot, PilotDTO>(pilot);
        }

        public PilotDTO UpdatePilot(int id, PilotDTO pilot)
        {
            try
            {
                Validation(pilot);
                Pilot modelPilot = mapper.Map<PilotDTO, Pilot>(pilot);
                Pilot result = unitOfWork.Pilots.Update(id, modelPilot);
                return mapper.Map<Pilot, PilotDTO>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validation(PilotDTO pilot)
        {
            var validationResult = validator.Validate(pilot);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
