using BHHCReason.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHHCReason.Data
{
  public interface IReasonRepository
  {
    IEnumerable<Reason> GetAllReasons { get; }
    IEnumerable<Reason> GetUsersReasons(string userId);
    void AddReason(Reason reason);
    Reason GetReasonById(int id, string userId);
    void UpdateReason(Reason reason);
    void DeleteReason(int id, string userId);
  }
}
