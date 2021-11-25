using JuliePro_Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class ScheduledSessionVM
    {
        public ScheduledSession ScheduledSession { get; set; }

        public IEnumerable<SelectListItem> TrainingList { get; set; }
        public Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
    }
}
