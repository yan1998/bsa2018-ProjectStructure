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
    public class CrewService : ICrewService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly CrewValidator validator;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new CrewValidator();
        }

        public CrewDTO AddCrew(CrewDTO crew)
        {
            Validation(crew);
            Crew modelCrew = mapper.Map<CrewDTO, Crew>(crew);
            return mapper.Map<Crew, CrewDTO>(unitOfWork.Crews.Create(modelCrew));
        }

        public void DeleteCrew(int id)
        {
            try
            {
                unitOfWork.Crews.Delete(id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
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
            try
            {
                Validation(crew);
                Crew modelCrew = mapper.Map<CrewDTO, Crew>(crew);
                Crew result = unitOfWork.Crews.Update(id, modelCrew);
                return mapper.Map<Crew, CrewDTO>(result);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void Validation(CrewDTO crew)
        {
            var validationResult = validator.Validate(crew);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
