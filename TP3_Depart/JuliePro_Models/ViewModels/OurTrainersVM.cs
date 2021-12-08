using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
  public class OurTrainersVM
  {
    public IEnumerable<Trainer> Trainers { get; set; }
    public IEnumerable<Speciality> Specialities { get; set; }
  }
}
