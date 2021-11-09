using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "StringLengthValidation")]
        public String FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "StringLengthValidation")]
        public String Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        public DataType Email { get; set; }

        [MaxLength(40, ErrorMessage = "MaxCaractersValidation")]
        public String Photo { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        //  [StringLength(400, MinimumLength = 100, ErrorMessage = "StringLengthValidation")]
        [Range(100, 400, ErrorMessage = "RangeValidation")]
        [Display(Name = "StartWeight")]
        public Double StartWeight { get; set; }


        [Display(Name = "TrainerId")]
        [ForeignKey("TrainerId")]
        public int Trainer_Id { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Trainer, propriété de navigation
        public Trainer Trainer { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Objective, propriété de navigation
        public ICollection<Objective> Objectives { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec ScheduledSession, propriété de navigation
        public ICollection<ScheduledSession> ScheduledSessions { get; set; }
    }
}
