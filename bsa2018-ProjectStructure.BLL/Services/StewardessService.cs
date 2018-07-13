using AutoMapper;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.Shared.DTO;
using System;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class StewardessService:IStewardessService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public StewardessDTO AddStewardess(StewardessDTO stewardess)
        {
            Stewardess modelStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
            return mapper.Map<Stewardess, StewardessDTO>(unitOfWork.Stewardess.Create(modelStewardess));
        }

        public void DeleteStewardess(int id)
        {
            unitOfWork.Stewardess.Delete(id);
        }

        public List<StewardessDTO> GetAllStewardess()
        {
            IEnumerable<Stewardess> stewardesses = unitOfWork.Stewardess.GetAll();
            return mapper.Map<IEnumerable<Stewardess>, List<StewardessDTO>>(stewardesses);
        }

        public StewardessDTO GetStewardess(int id)
        {
            Stewardess stewardess = unitOfWork.Stewardess.GetById(id);
            return mapper.Map<Stewardess, StewardessDTO>(stewardess);
        }

        public StewardessDTO UpdateStewardess(int id, StewardessDTO stewardess)
        {
            Stewardess modelStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
            Stewardess result = unitOfWork.Stewardess.Update(id, modelStewardess);
            return mapper.Map<Stewardess, StewardessDTO>(result);
        }
    }
}
