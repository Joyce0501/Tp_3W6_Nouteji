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
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "StringLengthValidation")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "StringLengthValidation")]
        public String LastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)] //Mettre aussi le type de input
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        public String Email { get; set; }

        [Display(Name = "Photo")]
        [MaxLength(40, ErrorMessage = "MaxLengthValidation")]
        public String Photo { get; set; }

     
        [MaxLength(40, ErrorMessage = "MaxLengthValidation")]
        public String Biography { get; set; }

        [Display(Name = "Speciality")]
        [ForeignKey("Speciality")]
        public int SpecialityId { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Speciality, propriété de navigation
        public virtual Speciality Speciality { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Customer
        public ICollection<Customer> Customers { get; set; }


    }
}
