using JuliePro_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class CustomerVM
    {
        public Customer Customer { get; set; }
        public IEnumerable<Objective> ObjectiveList { get; set; }
        public IEnumerable<ScheduledSession> ScheduledSessionList { get; set; }
    }
}
