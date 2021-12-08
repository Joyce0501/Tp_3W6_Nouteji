using JuliePro_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository.IRepository
{
    public interface IObjectiveRepository : IRepository<Objective>
    {
        void Update(Objective objective);
    }
}
