using bsa2018_ProjectStructure.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public class CrewsRepository : IRepository<Crew>
    {
        protected readonly DataContext context;

        public CrewsRepository(DataContext context)
        {
            this.context = context;
        }

        public Crew Create(Crew entity)
        {
            entity.Id = context.Crews.Last().Id + 1;
            context.Crews.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Crew crew = GetById(id);
            if (crew == null)
                throw new System.Exception("Incorrect id");
            context.Crews.Remove(crew);
        }

        public IEnumerable<Crew> GetAll()
        {
            return context.Crews.ToList();
        }

        public Crew GetById(int id)
        {
            return context.Crews.FirstOrDefault(c => c.Id == id);
        }

        public Crew Update(int id, Crew entity)
        {
            Crew crew = GetById(id);
            if (crew == null)
                throw new System.Exception("Incorrect id");
            crew.IdPilot = entity.IdPilot;
            crew.Pilot = context.Pilots.FirstOrDefault(p => p.Id == entity.IdPilot);
            crew.idStewardess = entity.idStewardess;
            return crew;
        }
    }
}
