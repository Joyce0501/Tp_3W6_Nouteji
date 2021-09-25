using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class Objective
    {

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "MinMaxCaractersValidation")]
        public String Name { get; set; }

        [StringLength(10, MinimumLength = 2, ErrorMessage = "StringLengthValidation")]
        public Double LostWeight { get; set; }

        [StringLength(45, MinimumLength = 2, ErrorMessage = "StringLengthValidation")]
        public Double DistanceKm { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
        public DateTime AchievedDate { get; set; }

        //OBLIGATOIRE Pour la relation plusieurs à plusieurs avec Customer
        public ICollection<Customer> Customers { get; set; }

        // Propriété de navigation vers Trainer
        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Trainer
        public ICollection<Trainer> Trainers { get; set; }

    }
}
