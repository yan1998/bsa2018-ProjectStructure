using AutoMapper;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class AircraftTypesService: IAircraftTypesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AircraftTypesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public AircraftTypeDTO AddAircraftType(AircraftTypeDTO aircraftType)
        {
            AircraftType modelAircraftType = mapper.Map<AircraftTypeDTO, AircraftType>(aircraftType);
            return mapper.Map<AircraftType, AircraftTypeDTO>(unitOfWork.AircraftTypes.Create(modelAircraftType));
        }

        public void DeleteAircraftType(int id)
        {
            unitOfWork.AircraftTypes.Delete(id);
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
            AircraftType modelAircraftTypes = mapper.Map<AircraftTypeDTO, AircraftType>(aircraftType);
            AircraftType result = unitOfWork.AircraftTypes.Update(id, modelAircraftTypes);
            return mapper.Map<AircraftType, AircraftTypeDTO>(result);
        }
    }
}
