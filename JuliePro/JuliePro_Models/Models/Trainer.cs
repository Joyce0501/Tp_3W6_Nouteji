using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class Trainer
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "MinMaxCaractersValidation")]
        public String FirstName;


        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "MinMaxCaractersValidation")]
        public String LastName;

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        public DataType Email;


        [StringLength(40, ErrorMessage = "MaxCaractersValidation")]
        public String Photo;


        [ForeignKey("SpecialityId")]
        public int Speciality_Id { get; set; }
        
        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Speciality, propriété de navigation
        public virtual Speciality Speciality { get; set; }
    }
}
