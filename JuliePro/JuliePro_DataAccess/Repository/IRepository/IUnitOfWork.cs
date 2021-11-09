using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        ITrainerRepository Trainer { get; }
        ISpecialityRepository Speciality { get; }
        ICustomerRepository Customer { get; }
        IObjectiveRepository Objective { get; }

        IEquipmentRepository Equipment { get; }
        IScheduledSessionRepository ScheduledSession { get; }
        ITrainingRepository Training { get; }
        ITrainingEquipmentRepository TrainingEquipment { get; }

        void Save();
    }

 
}
