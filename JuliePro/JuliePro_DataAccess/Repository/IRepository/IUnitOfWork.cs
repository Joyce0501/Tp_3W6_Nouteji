using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        ITrainerRepository Trainer { get; }
        ISpecialityRepository Speciality { get; }
        void Save();
    }

 
}
