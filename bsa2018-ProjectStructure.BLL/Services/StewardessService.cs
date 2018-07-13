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
    public class StewardessService:IStewardessService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly StewardessValidator validator;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new StewardessValidator();
        }

        public StewardessDTO AddStewardess(StewardessDTO stewardess)
        {
            Validation(stewardess);
            Stewardess modelStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
            return mapper.Map<Stewardess, StewardessDTO>(unitOfWork.Stewardess.Create(modelStewardess));
        }

        public void DeleteStewardess(int id)
        {
            try
            {
                unitOfWork.Stewardess.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
            {
                Validation(stewardess);
                Stewardess modelStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
                Stewardess result = unitOfWork.Stewardess.Update(id, modelStewardess);
                return mapper.Map<Stewardess, StewardessDTO>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        private void Validation(StewardessDTO stewardess)
        {
            var validationResult = validator.Validate(stewardess);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
