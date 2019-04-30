using BHHCReason.Data;
using BHHCReason.Models;
using Moq;
using System;
using System.Collections.Generic;

namespace BHHCReason.Tests.Models
{
  public class RepositoryMocks
  {
    public static Mock<IReasonRepository> ReasonRepository()
    {
      var userId1 = "024f83a4-7e64-4c7f-9330-197b48549ee3";
      var reasons = ReasonList.ListOfReasons();
      var mockReasonRepository = new Mock<IReasonRepository>();
      mockReasonRepository.Setup(repo => repo.GetAllReasons).Returns(reasons);
      mockReasonRepository.Setup(repo => repo.GetReasonById(It.IsAny<int>(), userId1))
          .Returns(reasons[0]);
      return mockReasonRepository;
    }
  }
}
