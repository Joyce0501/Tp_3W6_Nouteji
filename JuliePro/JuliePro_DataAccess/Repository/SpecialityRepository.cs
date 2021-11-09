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
    public class SpecialityRepository : Repository<Speciality>, ISpecialityRepository
    {
        private readonly JulieProDbContext _db;

        public SpecialityRepository(JulieProDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Speciality speciality)
        {
            _db.Update(speciality);

        }
    }
}
