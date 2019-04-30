using BHHCReason.Data;
using BHHCReason.Models;
using BHHCReason.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BHHCReason.Controllers
{
  [Authorize]
  public class ReasonController : Controller
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IReasonRepository _repo;

    public ReasonController(UserManager<IdentityUser> userManager,
      IReasonRepository repo) {
        _userManager = userManager; _repo = repo;
    }

    [HttpGet]
    public async Task<ViewResult> Index()
    {
      var user = await GetUser();
      var reasons = _repo.GetUsersReasons(user.Id);
      var vm = new ReasonDisplayViewModel {
        UserId = user.Id, UserName = user.UserName, Reasons = reasons };
      
      return View(vm);
    }

    [HttpGet]
    public IActionResult Add()
    {
      var vm = new Reason();
      return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(Reason vm)
    {
      if (ModelState.IsValid)
      {
        vm.Created = vm.Updated = DateTime.Now;
        var user = await GetUser();
        vm.UserId = user.Id;
        _repo.AddReason(vm);
        return RedirectToAction("Index");
      }

      return View(vm);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var vm = new Reason();
      var user = (await GetUser());      

      vm = _repo.GetReasonById(id, user.Id); 
      return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Reason vm)
    {
      if (ModelState.IsValid)
      {
        vm.Updated = DateTime.Now;
        _repo.UpdateReason(vm);
        return RedirectToAction("Index");
      }

      return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id) {
      var vm = new Reason();

      var user = await GetUser();

      vm = _repo.GetReasonById(id, user.Id);
      return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Reason vm) {
      _repo.DeleteReason(vm.Id, vm.UserId);
      return RedirectToAction("Index");
    }

    private async Task<IdentityUser> GetUser()
    {
      var userName = User.Identity.Name;
      return await _userManager.FindByNameAsync(userName);
    }
    
  }
}