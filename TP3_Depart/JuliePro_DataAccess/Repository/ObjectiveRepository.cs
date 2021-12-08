using JuliePro_DataAccess.Data;
using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository
{
    public class ObjectiveRepository : Repository<Objective>, IObjectiveRepository
    {
        private readonly JulieProDbContext _db;

        public ObjectiveRepository(JulieProDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Objective objective)
        {
            _db.Update(objective);
        }
    }
}
