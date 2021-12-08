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
    public Objective ActiveObjective { get; set; }
    public IEnumerable<ScheduledSession> SheduledSessionsList { get; set; }
    public IEnumerable<Objective> ObjectivessList { get; set; }
}
}
