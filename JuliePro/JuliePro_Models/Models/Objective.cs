﻿using System;
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


        [Range(2, 10, ErrorMessage = "RangeValidation")]
        [Display(Name = "LostWeight")]
        public Double LostWeight { get; set; }

        [Range(2, 45, ErrorMessage = "RangeValidation")]
        [Display(Name = "DistanceKm")]
        public Double DistanceKm { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AchievedDate { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Customer

        [Display(Name = "CustomerId")]
        [ForeignKey("CustomerId")]
        public int Customer_Id { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Customer, propriété de navigation
        public Customer Customer { get; set; }



    }
}

