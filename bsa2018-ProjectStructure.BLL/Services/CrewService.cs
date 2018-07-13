using AutoMapper;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.Shared.DTO;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class CrewService : ICrewService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public CrewDTO AddCrew(CrewDTO crew)
        {
            Crew modelCrew = mapper.Map<CrewDTO, Crew>(crew);
            return mapper.Map<Crew, CrewDTO>(unitOfWork.Crews.Create(modelCrew));
        }

        public void DeleteCrew(int id)
        {
            unitOfWork.Crews.Delete(id);
        }

        public List<CrewDTO> GetAllCrews()
        {
            IEnumerable<Crew> crews = unitOfWork.Crews.GetAll();
            return mapper.Map<IEnumerable<Crew>, List<CrewDTO>>(crews);
        }

        public CrewDTO GetCrew(int id)
        {
            Crew crew = unitOfWork.Crews.GetById(id);
            return mapper.Map<Crew, CrewDTO>(crew);
        }

        public CrewDTO UpdateCrew(int id, CrewDTO crew)
        {
            Crew modelCrew = mapper.Map<CrewDTO, Crew>(crew);
            Crew result = unitOfWork.Crews.Update(id, modelCrew);
            return mapper.Map<Crew, CrewDTO>(result);
        }
    }
}
