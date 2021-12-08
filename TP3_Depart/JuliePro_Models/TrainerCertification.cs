using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    public class TrainerCertification
    {
        [ForeignKey("Trainer")]
        public int Trainer_Id { get; set; }

        [ForeignKey("Certification")]
        public int Certification_Id { get; set; }

        public Trainer Trainer { get; set; }

        public Certification Certification { get; set; }
    }
}
