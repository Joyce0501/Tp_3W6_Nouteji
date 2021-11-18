using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuliePro_Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JuliePro_Models.ViewModels
{
    public class TrainerVM
    {
        public Trainer Trainer { get; set; }

        public IEnumerable<SelectListItem> SpecialityList { get; set; }

        public IEnumerable<Speciality> Specialities { get; set; }

        public IEnumerable<Trainer> Trainers { get; set; }

    }
}
