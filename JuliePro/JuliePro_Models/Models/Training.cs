using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class Training
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Category { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec ScheduleSession, propriété de navigation

        public ICollection<ScheduledSession> ScheduledSessions { get; set; }

        // Propriété de navigation pour la relation plusieurs a plusieurs avec equipment
        public ICollection<TrainingEquipment> TrainingEquipments { get; set; }


    }
}
