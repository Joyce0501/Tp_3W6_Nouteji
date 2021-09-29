using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.Models
{
    public class ScheduledSession
    {
        public int Id { get; set; }
        
        public String Description { get; set; }

        public DateTime Date { get; set; }

        public int DurationMin { get; set; }

        public Boolean WithTrainer { get; set; }

        public Boolean Complete { get; set; }

        [ForeignKey("TrainerId")]
        public int Training_Id { get; set; }

        //OBLIGATOIRE Pour la relation 1 à plusieurs avec Training, propriété de navigation
        public Trainer Training { get; set; }

    }
}
