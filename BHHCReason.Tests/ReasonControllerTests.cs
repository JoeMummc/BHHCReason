using BHHCReason.Tests.Models;
using BHHCReason.Controllers;
using BHHCReason.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BHHCReason.Tests
{
  public class ReasonControllerTests
  {
    // To be implemented.  Need to fix mocking UserManager parameterless constructor issue
    //[Fact]
    public void Index_ReturnsAViewResult_ContainsAllReasons()
    {
      //arrange
      var mockReasonRepository = RepositoryMocks.ReasonRepository();
      //var mockUserStore = new Mock<IUserStore<IdentityUser>>();
      //var mockUserManager = new UserManager<IdentityUser>(mockUserStore.Object);
      var mockUserManager = new Mock<UserManager<IdentityUser>>();
      //mockUserManager.Setup(um => um.FindByNameAsync(It.IsAny<string>()))
      //  .ReturnsAsync(new IdentityUser { Id = "024f83a4-7e64-4c7f-9330-197b48549ee3" });

      var reasonController = new ReasonController(mockUserManager.Object, mockReasonRepository.Object);

      //act
      var result = reasonController.Index();

      //assert
      var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
      var reasons = Assert.IsAssignableFrom<IEnumerable<Reason>>(viewResult.ViewData.Model);
      Assert.Equal(15, reasons.Count());
    }
  }
}
