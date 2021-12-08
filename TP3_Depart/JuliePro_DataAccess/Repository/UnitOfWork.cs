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

        public ITrainerRepository Trainer { get; private set; }

        public ISpecialityRepository Speciality { get; private set; }

        public ICustomerRepository Customer { get; private set; }

        public IObjectiveRepository Objective { get; private set; }

        public IScheduledSessionRepository ScheduledSession { get; private set; }

        public ITrainingRepository Training { get; private set; }

        public IEquipmentRepository Equipment { get; private set; }

        public ITrainingEquipmentRepository TrainingEquipment { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public ICalendarEventRepository CalendarEvent { get; private set; }

        public ICertificationRepository Certification { get; private set; }

        public ITrainerCertificationRepository TrainerCertification { get; private set; }

        public UnitOfWork(JulieProDbContext db)
        {
            _db = db;
            Trainer = new TrainerRepository(_db);
            Speciality = new SpecialityRepository(_db);
            Customer = new CustomerRepository(_db);
            Objective = new ObjectiveRepository(_db);
            ScheduledSession = new ScheduledSessionRepository(_db);
            Training = new TrainingRepository(_db);
            Equipment = new EquipmentRepository(_db);
            TrainingEquipment = new TrainingEquipmentRepository(_db);
            Certification = new CertificationRepository(_db);
            TrainerCertification = new TrainerCertificationRepository(_db);
            CalendarEvent = new CalendarEventRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
