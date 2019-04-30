using BHHCReason.Models;
using System;
using System.Collections.Generic;

namespace BHHCReason.Tests.Models
{
  public class ReasonList
  {
    public static List<Reason> ListOfReasons()
    {
      var text = "Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
      "laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
      "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia " +
      "deserunt mollit anim id est laborum.";
      var userId1 = "024f83a4-7e64-4c7f-9330-197b48549ee3";
      var userId2 = "027b7b25-083f-4f39-86a7-cf04cbcb84a3";
      var userId3 = "11dd4a30-4cac-41a8-947b-4d56ca21856f";
      var userId4 = "43ad7058-035b-49ca-896d-65b81dff9e08";
      var userId5 = "57dace7f-c3a3-4a18-a0f1-77c738b27709";
      var reasons = new List<Reason> {
        new Reason { UserId = userId1, Text = "User1@bhhc.com Reason 1 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId1, Text = "User1@bhhc.com Reason 2 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId1, Text = "User1@bhhc.com Reason 3 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId2, Text = "User2@bhhc.com Reason 1 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId2, Text = "User2@bhhc.com Reason 2 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId2, Text = "User2@bhhc.com Reason 3 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId3, Text = "User3@bhhc.com Reason 1 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId3, Text = "User3@bhhc.com Reason 2 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId3, Text = "User3@bhhc.com Reason 3 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId4, Text = "User4@bhhc.com Reason 1 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId4, Text = "User4@bhhc.com Reason 2 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId4, Text = "User4@bhhc.com Reason 3 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId5, Text = "User5@bhhc.com Reason 1 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId5, Text = "User5@bhhc.com Reason 2 " + text,
          Created = DateTime.Now, Updated = DateTime.Now },
        new Reason { UserId = userId5, Text = "User5@bhhc.com Reason 3 " + text,
          Created = DateTime.Now, Updated = DateTime.Now } };

      return reasons;
    }
  }
}
