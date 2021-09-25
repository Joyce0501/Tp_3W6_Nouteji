﻿
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
            Trainer = new TrainerRepository(_db);
            Speciality = new SpecialityRepository(_db);
            Customer = new CustomerRepository(_db);
            Objective = new ObjectiveRepository(_db);

        }

        public ITrainerRepository Trainer { get; private set; }

        public ISpecialityRepository Speciality { get; private set; }

        public IObjectiveRepository Objective { get; private set; }

        public ICustomerRepository Customer { get; private set; }


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
