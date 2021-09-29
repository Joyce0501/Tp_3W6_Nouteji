using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository.IRepository
{
    public interface ITrainingEquipmentRepository : IRepository<TrainingEquipmentRepository>
    {
        void Update(TrainingEquipmentRepository trainingequipment);
    }
}
