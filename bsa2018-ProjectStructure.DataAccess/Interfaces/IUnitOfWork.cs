using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bsa2018_ProjectStructure.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChages();
        Task SaveChangesAsync();
    }
}
