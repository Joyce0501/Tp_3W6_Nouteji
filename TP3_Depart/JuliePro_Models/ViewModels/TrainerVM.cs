using JuliePro_Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
  public class TrainerVM
  {
    public Trainer Trainer { get; set; }
    public IEnumerable<SelectListItem> SpecialityList { get; set; }
  }
}
