using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class ScheduledSession
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "StringLengthValidation")]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        public DateTime Date { get; set; }


        [Range(20, 90, ErrorMessage = "RangeValidation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        public int DurationMin { get; set; }

        public Boolean WithTrainer { get; set; }

        public Boolean Complete { get; set; }

        [ForeignKey("TrainerId")]
        public int Training_Id { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Training, propriété de navigation
        public Trainer Training { get; set; }

        [Display(Name = "CustomerId")]
        [ForeignKey("CustomerId")]
        public int Customer_Id { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Customer, propriété de navigation
        public Customer Customer { get; set; }

    }
}
