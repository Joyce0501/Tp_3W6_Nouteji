﻿using JuliePro_DataAccess.Data;
using JuliePro_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository
{
    public class TrainingEquipmentRepository : RepositoryAsync<TrainingEquipmentRepository>, ITrainingEquipmentRepository
    {
        private readonly JulieProDbContext _db;

        public TrainingEquipmentRepository(JulieProDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TrainingEquipmentRepository trainingequipment)
        {
            _db.Update(trainingequipment);

        }
    }
}
