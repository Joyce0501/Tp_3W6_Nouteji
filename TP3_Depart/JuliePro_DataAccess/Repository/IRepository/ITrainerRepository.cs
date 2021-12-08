using JuliePro_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository.IRepository
{
    public interface ITrainerRepository : IRepository<Trainer>
    {
        IEnumerable<Trainer> GetAllActive();
        void Update(Trainer trainer);
    }
}
