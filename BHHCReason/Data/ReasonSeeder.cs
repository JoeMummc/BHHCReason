using BHHCReason.Data;
using BHHCReason.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHHCReader.Data
{
  public class ReasonSeeder
  {
    private readonly ReasonContext _ctx;
    //private readonly IHostingEnvironment _hosting;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ReasonSeeder(ReasonContext ctx, // IHostingEnvironment hosting, 
      UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      _ctx = ctx; _userManager = userManager; _roleManager = roleManager; //_hosting = hosting; 
    }

    public async Task SeedAsync()
    {
      _ctx.Database.EnsureCreated();

      if (!_ctx.Roles.Any())
      {
        var roleList = new List<IdentityRole> {
          new IdentityRole { Name = "Administrators" },
          new IdentityRole { Name = "Users" }         };

        foreach (var role in roleList) { await _roleManager.CreateAsync(role); }
      }

      await CreateUser("admin@bhhc.com");

      for (int i = 1; i < 101; i++) {
        var userName = $"User{i}@bhhc.com";
        await CreateUser(userName); }

      var userList = _ctx.Users.Where(n => n.UserName != "admin@bhhc.com").ToList();

      if (!_ctx.UserRoles.Any()) {
        var adminUser = await _userManager.FindByEmailAsync("admin@bhhc.com");
        await _userManager.AddToRoleAsync(adminUser, "Administrators");
        foreach (var user in userList)
        { await _userManager.AddToRoleAsync(user, "Users"); }
      }

      if (!_ctx.Reason.Any())
      {
        var reasons = new List<Reason>();
        foreach (var user in userList)
        {
          for (int i = 1; i < 4; i++) {
            reasons.Add( new Reason() { UserId = user.Id,
              Text = $"{user.UserName} Reason{i} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
              Created = DateTime.Now, Updated = DateTime.Now } ); }
        }
        _ctx.Reason.AddRange(reasons);
        await _ctx.SaveChangesAsync();
      }
    }

    private async Task CreateUser(string userName)
    {
      IdentityUser user = await _userManager.FindByEmailAsync(userName);
      if (user == null)
      {
        user = new IdentityUser() { Email = userName, UserName = userName };

        var result = await _userManager.CreateAsync(user, "P@$$w0rd");
        if (result != IdentityResult.Success)
          throw new InvalidOperationException("Could not create new user in seeder");
      }
    }
  }
}


