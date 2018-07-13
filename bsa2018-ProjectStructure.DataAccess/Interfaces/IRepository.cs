using System.Collections.Generic;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public interface  IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Create(TEntity entity);

        TEntity Update(int id, TEntity entity);

        void Delete(int id);
    }
}
