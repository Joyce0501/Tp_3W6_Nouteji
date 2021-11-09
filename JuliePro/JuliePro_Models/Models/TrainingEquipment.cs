using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class TrainingEquipment
    {
        //[Key]
        [ForeignKey("Training")]
        public int Training_Id { get; set; }
        //[Key]
        [ForeignKey("Equipment")]
        public int Equipment_Id { get; set; }

        // Propriétés de navigation
        public Training Training { get; set; }
        public Equipment Equipment { get; set; }

    }
}
