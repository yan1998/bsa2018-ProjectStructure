using bsa2018_ProjectStructure.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
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

        public void Create(Crew entity)
        {
            entity.Id = context.Crews.Last().Id + 1;
            context.Crews.Add(entity);
        }

        public void Delete(int id)
        {
            context.Crews.Remove(GetById(id));
        }

        public IEnumerable<Crew> GetAll()
        {
            return context.Crews.ToList();
        }

        public Crew GetById(int id)
        {
            return context.Crews.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Crew entity)
        {
           
        }
    }
}
