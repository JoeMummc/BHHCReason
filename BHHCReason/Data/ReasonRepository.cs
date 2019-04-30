using BHHCReason.Models;
using System.Collections.Generic;
using System.Linq;

namespace BHHCReason.Data
{
  public class ReasonRepository : IReasonRepository
  {
    private readonly ReasonContext _ctx;

    public ReasonRepository(ReasonContext ctx)
    {
      _ctx = ctx;
    }

    public IEnumerable<Reason> GetAllReasons { get { return _ctx.Reason; } }

    public void AddReason(Reason reason)
    {
      _ctx.Reason.Add(reason);
      _ctx.SaveChanges();

    }

    public Reason GetReasonById(int id, string userId)
    {
      return _ctx.Reason.Where(r => r.Id == id && r.UserId == userId).SingleOrDefault();
    }

    public IEnumerable<Reason> GetUsersReasons(string userId)
    {
      return _ctx.Reason.Where(r => r.UserId == userId).ToList();
    }

    public void UpdateReason(Reason reason)
    {
      _ctx.Reason.Update(reason);
      _ctx.SaveChanges();
    }

    public void DeleteReason(int id, string userId)
    {
      var reason = _ctx.Reason.Where(r => r.Id == id && r.UserId == userId).SingleOrDefault();
      _ctx.Reason.Remove(reason);
      _ctx.SaveChanges();
    }
  }
}
