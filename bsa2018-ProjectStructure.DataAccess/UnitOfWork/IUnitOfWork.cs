using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bsa2018_ProjectStructure.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChages();
        Task SaveChangesAsync();
    }
}
