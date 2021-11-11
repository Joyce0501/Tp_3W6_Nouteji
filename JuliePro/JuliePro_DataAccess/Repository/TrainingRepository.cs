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
    public class TrainingRepository : RepositoryAsync<Training>, ITrainingRepository
    {
        private readonly JulieProDbContext _db;

        public TrainingRepository(JulieProDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Training training)
        {
            _db.Update(training);

        }
    }
}
