using System;

namespace BHHCReason.Models
{
  public class Reason
  {
    public int Id { get; set; }

    public string UserId { get; set; }

    public string Text { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
  }
}
