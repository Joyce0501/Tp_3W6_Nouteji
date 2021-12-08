using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    public class Certification
    {
        public int Id { get; set; }

        [Display(Name = "CertificationTitle")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(45, MinimumLength = 15, ErrorMessage = "MinMaxLengthValidation")]
        public string Title { get; set; }

        [Display(Name = "CertificationCenter")]
        [StringLength(30, ErrorMessage = "CertificationCenterLengthValidation")]
        public string CertificationCenter { get; set; }

        public ICollection<TrainerCertification> TrainerCertifications { get; set; }
    }
}
