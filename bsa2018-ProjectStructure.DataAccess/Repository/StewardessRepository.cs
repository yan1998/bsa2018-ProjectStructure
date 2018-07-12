using bsa2018_ProjectStructure.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsa2018_ProjectStructure.DataAccess.Repository
{
    public class StewardessRepository : IRepository<Stewardess>
    {
        protected readonly DataContext context;

        public StewardessRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(Stewardess entity)
        {
            entity.Id = context.Stewardess.Last().Id + 1;
            context.Stewardess.Add(entity);
        }

        public void Delete(int id)
        {
            Stewardess stewardess = GetById(id);
            var crews=context.Crews.Where(c => c.Stewardess.Contains(stewardess));
            foreach (var crew in crews)
                crew.Stewardess.Remove(stewardess);
            context.Stewardess.Remove(stewardess);
        }

        public IEnumerable<Stewardess> Get()
        {
            return context.Stewardess.ToList();
        }

        public Stewardess GetById(int id)
        {
            return context.Stewardess.FirstOrDefault(s=>s.Id==id);
        }

        public void Update(Stewardess entity)
        {

        }
    }
}
