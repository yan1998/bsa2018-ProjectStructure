using AutoMapper;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AircraftService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public AircraftDTO AddAircraft(AircraftDTO aircraft)
        {
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
                Aircraft modelAircraft = mapper.Map<AircraftDTO, Aircraft>(aircraft);
                Aircraft result = unitOfWork.Aircrafts.Update(id, modelAircraft);
                return mapper.Map<Aircraft, AircraftDTO>(result);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
