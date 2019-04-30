using BHHCReason.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHHCReason.ViewModels
{
  public class ReasonDisplayViewModel
  {
    public string UserId { get; set; }
    public string UserName { get; set; }
    public IEnumerable<Reason> Reasons { get; set; }
  }
}
