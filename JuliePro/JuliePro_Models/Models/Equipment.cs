using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class Equipment
    {
        public int Id { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "StringLengthValidation")]
        public String Name { get; set; }


        // Propriété de navigation pour la relation plusieurs a plusieurs avec Training
        public ICollection<TrainingEquipment> TrainingEquipments { get; set; }
    }
}
