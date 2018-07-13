using bsa2018_ProjectStructure.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public class PilotsRepository : IRepository<Pilot>
    {
        protected readonly DataContext context;

        public PilotsRepository(DataContext context)
        {
            this.context = context;
        }

        public Pilot Create(Pilot entity)
        {
            entity.Id = context.Pilots.Last().Id + 1;
            context.Pilots.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Pilot pilot = GetById(id);
            var crews=context.Crews.Where(c => c.Pilot.Id == pilot.Id);
            foreach (var crew in crews)
            {
                crew.Pilot = null;
                crew.IdPilot = 0;
            }
            context.Pilots.Remove(pilot);
        }

        public IEnumerable<Pilot> GetAll()
        {
            return context.Pilots.ToList();
        }

        public Pilot GetById(int id)
        {
            return context.Pilots.FirstOrDefault(s => s.Id == id);
        }

        public Pilot Update(int id, Pilot entity)
        {
            Pilot pilot = GetById(id);
            pilot.Birthday = entity.Birthday;
            pilot.Experience = entity.Experience;
            pilot.Name = entity.Name;
            pilot.Surname = entity.Surname;
            return pilot;
        }
    }
}
