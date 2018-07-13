using bsa2018_ProjectStructure.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public class StewardessRepository : IRepository<Stewardess>
    {
        protected readonly DataContext context;

        public StewardessRepository(DataContext context)
        {
            this.context = context;
        }

        public Stewardess Create(Stewardess entity)
        {
            entity.Id = context.Stewardess.Last().Id + 1;
            context.Stewardess.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Stewardess stewardess = GetById(id);
            if (stewardess == null)
                throw new System.Exception("Incorrect id");
            var crews=context.Crews.Where(c => c.idStewardess.Contains(stewardess.Id));
            foreach (var crew in crews)
                crew.idStewardess.Remove(stewardess.Id);
            context.Stewardess.Remove(stewardess);
        }

        public IEnumerable<Stewardess> GetAll()
        {
            return context.Stewardess.ToList();
        }

        public Stewardess GetById(int id)
        {
            return context.Stewardess.FirstOrDefault(s=>s.Id==id);
        }

        public Stewardess Update(int id, Stewardess entity)
        {
            Stewardess stewardess = GetById(id);
            if (stewardess == null)
                throw new System.Exception("Incorrect id");
            stewardess.Birthday = entity.Birthday;
            stewardess.Name = entity.Name;
            stewardess.Surname = entity.Surname;
            return stewardess;
        }
    }
}
