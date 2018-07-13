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
    public class AircraftTypesService: IAircraftTypesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly AircraftTypeValidator validator;

        public AircraftTypesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new AircraftTypeValidator();
        }

        public AircraftTypeDTO AddAircraftType(AircraftTypeDTO aircraftType)
        {
            Validation(aircraftType);
            AircraftType modelAircraftType = mapper.Map<AircraftTypeDTO, AircraftType>(aircraftType);
            return mapper.Map<AircraftType, AircraftTypeDTO>(unitOfWork.AircraftTypes.Create(modelAircraftType));
        }

        public void DeleteAircraftType(int id)
        {
            try
            {
                unitOfWork.AircraftTypes.Delete(id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public AircraftTypeDTO GetAircraftType(int id)
        {
            AircraftType aircraftType = unitOfWork.AircraftTypes.GetById(id);
            return mapper.Map<AircraftType, AircraftTypeDTO>(aircraftType);
        }

        public List<AircraftTypeDTO> GetAllAircraftTypes()
        {
            IEnumerable<AircraftType> aircraftsTypes = unitOfWork.AircraftTypes.GetAll();
            return mapper.Map<IEnumerable<AircraftType>, List<AircraftTypeDTO>>(aircraftsTypes);
        }

        public AircraftTypeDTO UpdateAircraftType(int id, AircraftTypeDTO aircraftType)
        {
            try
            {
                Validation(aircraftType);
                AircraftType modelAircraftTypes = mapper.Map<AircraftTypeDTO, AircraftType>(aircraftType);
                AircraftType result = unitOfWork.AircraftTypes.Update(id, modelAircraftTypes);
                return mapper.Map<AircraftType, AircraftTypeDTO>(result);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void Validation(AircraftTypeDTO aircraftType)
        {
            var validationResult = validator.Validate(aircraftType);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
