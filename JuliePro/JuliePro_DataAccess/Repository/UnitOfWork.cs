
using JuliePro_DataAccess.Data;
using JuliePro_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JulieProDbContext _db;

        public UnitOfWork(JulieProDbContext db)
        {
            _db = db;
        
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        // Doit être ajouté parce que absent du Repo générique
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
