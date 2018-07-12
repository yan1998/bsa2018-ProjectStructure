using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public interface  IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);
    }
}
