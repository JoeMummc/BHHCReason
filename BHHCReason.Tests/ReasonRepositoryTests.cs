using BHHCReason.Tests.Models;
using BHHCReason.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//using Moq;
using Xunit;

namespace BHHCReason.Tests
{
  // Using EntityFrameworkCore.InMemory database
  public class ReasonRepositoryTests
  {
    private readonly DbContextOptions<ReasonContext> _options;
    private string _userId1 = "024f83a4-7e64-4c7f-9330-197b48549ee3";

    public ReasonRepositoryTests()
    {
      //arrange
      _options = new DbContextOptionsBuilder<ReasonContext>()
        .UseInMemoryDatabase(databaseName: "Reasons").Options;

      // Insert seed data into the database using one instance of the context
      using (var context = new ReasonContext(_options))
      {
        foreach (var item in ReasonList.ListOfReasons())
        { context.Reason.Add(item); }
        context.SaveChanges();
      }
    }


    // To be implemented.  The InMemory database gets added to multiple times
    [Fact(Skip = "true")]
    public void GetAllReasons()
    {
      // Use a clean instance of the context to run the test
      using (var context = new ReasonContext(_options))
      {
        ReasonRepository reasonRepository = new ReasonRepository(context);
        //act
        var reasons = reasonRepository.GetAllReasons;

        //assert
        Assert.Equal(15, reasons.Count());
      }
    }

    [Theory]
    [InlineData(1, "024f83a4-7e64-4c7f-9330-197b48549ee3", "User1@bhhc.com Reason 1 ")]
    [InlineData(2, "024f83a4-7e64-4c7f-9330-197b48549ee3", "User1@bhhc.com Reason 2 ")]
    [InlineData(3, "024f83a4-7e64-4c7f-9330-197b48549ee3", "User1@bhhc.com Reason 3 ")]
    [InlineData(4, "027b7b25-083f-4f39-86a7-cf04cbcb84a3", "User2@bhhc.com Reason 1 ")]
    [InlineData(5, "027b7b25-083f-4f39-86a7-cf04cbcb84a3", "User2@bhhc.com Reason 2 ")]
    [InlineData(6, "027b7b25-083f-4f39-86a7-cf04cbcb84a3", "User2@bhhc.com Reason 3 ")]
    // ********************* Adding more parameters adds to the InMemory DB and
    //                       causes GetAllReasons to fail ***********************
    [InlineData(7, "11dd4a30-4cac-41a8-947b-4d56ca21856f", "User3@bhhc.com Reason 1 ")]
    [InlineData(8, "11dd4a30-4cac-41a8-947b-4d56ca21856f", "User3@bhhc.com Reason 2 ")]
    [InlineData(9, "11dd4a30-4cac-41a8-947b-4d56ca21856f", "User3@bhhc.com Reason 3 ")]
    [InlineData(10, "43ad7058-035b-49ca-896d-65b81dff9e08", "User4@bhhc.com Reason 1 ")]
    [InlineData(11, "43ad7058-035b-49ca-896d-65b81dff9e08", "User4@bhhc.com Reason 2 ")]
    [InlineData(12, "43ad7058-035b-49ca-896d-65b81dff9e08", "User4@bhhc.com Reason 3 ")]
    [InlineData(13, "57dace7f-c3a3-4a18-a0f1-77c738b27709", "User5@bhhc.com Reason 1 ")]
    [InlineData(14, "57dace7f-c3a3-4a18-a0f1-77c738b27709", "User5@bhhc.com Reason 2 ")]
    [InlineData(15, "57dace7f-c3a3-4a18-a0f1-77c738b27709", "User5@bhhc.com Reason 3 ")]
    public void GetReasonById(int id, string userId, string text)
    {
      // Use a clean instance of the context to run the test
      using (var context = new ReasonContext(_options))
      {
        ReasonRepository reasonRepository = new ReasonRepository(context);
        //act
        var reason = reasonRepository
          .GetReasonById(id, userId);
        var isTrue = reason.Text.Contains(text);
        //assert
        Assert.True(isTrue);
        Assert.Equal(reason.UserId, userId);
      }
    }

    [Fact]
    public void GetReasonById_WrongUserId_ReturnsNull()
    {
      // Use a clean instance of the context to run the test
      using (var context = new ReasonContext(_options))
      {
        ReasonRepository reasonRepository = new ReasonRepository(context);
        //act
        var userId = "487f83a4-7e64-4c7f-9330-197b48549ee3";
        var reason = reasonRepository
          .GetReasonById(1, userId);
        //assert
        Assert.Null(reason);
      }
    }

    [Fact]
    public void GetReasonById_WrongId_ReturnsNull()
    {
      // Use a clean instance of the context to run the test
      using (var context = new ReasonContext(_options))
      {
        ReasonRepository reasonRepository = new ReasonRepository(context);
        //act
        var reason = reasonRepository
          .GetReasonById(5, _userId1);
        //assert
        Assert.Null(reason);
      }
    }
  }
}

