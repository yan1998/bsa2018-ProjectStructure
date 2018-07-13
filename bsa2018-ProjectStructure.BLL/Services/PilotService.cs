using AutoMapper;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.Shared.DTO;
using System;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class PilotService:IPilotService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public PilotDTO AddPilot(PilotDTO pilot)
        {
            Pilot modelPilot = mapper.Map<PilotDTO, Pilot>(pilot);
            return mapper.Map<Pilot, PilotDTO>(unitOfWork.Pilots.Create(modelPilot));
        }

        public void DeletePilot(int id)
        {
            unitOfWork.Pilots.Delete(id);
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
            Pilot modelPilot = mapper.Map<PilotDTO, Pilot>(pilot);
            Pilot result = unitOfWork.Pilots.Update(id, modelPilot);
            return mapper.Map<Pilot, PilotDTO>(result);
        }
    }
}
