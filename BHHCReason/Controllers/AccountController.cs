using BHHCReason.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BHHCReason.Controllers
{
  [Authorize]
  public class AccountController : Controller
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager,
      UserManager<IdentityUser> userManager) {
      _signInManager = signInManager; _userManager = userManager; }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
      return View(new LoginViewModel
      {
        ReturnUrl = returnUrl
      });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
      if (!ModelState.IsValid)
        return View(loginViewModel);

      var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

      if (user != null)
      {
        var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
        if (result.Succeeded)
        {
          if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
            return RedirectToAction("Index", "Reason");

          return Redirect(loginViewModel.ReturnUrl);
        }
      }

      ModelState.AddModelError("", "Username/password not found");
      return View(loginViewModel);
    }

    [AllowAnonymous]
    public IActionResult Register()
    { return View(); }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
      if (ModelState.IsValid)
      {
        var user = new IdentityUser() { UserName = registerViewModel.UserName,
          Email = registerViewModel.UserName };
        var result = await _userManager.CreateAsync(user, registerViewModel.Password);

        if (result.Succeeded)
        {
          await _userManager.AddToRoleAsync(user, "Users");
          await _signInManager.PasswordSignInAsync(user, registerViewModel.Password, false, false);
          return RedirectToAction("Index", "Reason");
        }
      }
      return View(registerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

  }
}
