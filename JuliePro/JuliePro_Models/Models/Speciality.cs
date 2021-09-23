using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "MinMaxCaractersValidation")]
        public String Name { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Trainer
        public ICollection <Trainer> Trainers { get; set; }
    }
}
