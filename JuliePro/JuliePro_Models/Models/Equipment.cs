using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public String Name { get; set; }


        // Propriété de navigation pour la relation plusieurs a plusieurs avec Training
        public ICollection<TrainingEquipment> TrainingEquipments { get; set; }
    }
}
