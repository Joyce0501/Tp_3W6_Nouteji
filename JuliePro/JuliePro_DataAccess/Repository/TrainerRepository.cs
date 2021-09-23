using JuliePro_DataAccess.Data;
using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository
{
    public class TrainerRepository : Repository<Trainer>, ITrainerRepository
    {
        private readonly JulieProDbContext _db;

        public TrainerRepository(JulieProDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Trainer trainer)
        {
            _db.Update(trainer);

        }
    }
}

