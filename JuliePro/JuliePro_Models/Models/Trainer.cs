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
        [StringLength(25, MinimumLength = 10, ErrorMessage = "StringLengthValidation")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "StringLengthValidation")]
        public String LastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)] //Mettre aussi le type de input
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        public DataType Email { get; set; }

        [Display(Name = "Photo")]
        [MaxLength(40, ErrorMessage = "MaxCaractersValidation")]
        public String Photo { get; set; }

        [Display(Name = "SpecialityId")]
        [ForeignKey("SpecialityId")]
        public int Speciality_Id { get; set; }
        
        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Speciality, propriété de navigation
        public  Speciality Speciality { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Customer
        public ICollection<Customer> Customers { get; set; }


        //#region
         
        //table intermédiaires pour la relation plusieurs à plusieurs avec Objective

        //[ForeignKey("Customer")]
        //public int Customer_Id { get; set; }

        //[ForeignKey("Objective")]
        //public int Objective_Id { get; set; }

        //public Customer customer { get; set; }

        //public Objective objective { get; set; }
        //#endregion


    }
}
