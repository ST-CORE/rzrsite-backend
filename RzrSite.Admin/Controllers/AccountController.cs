using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repository;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  public class AccountController : Controller
  {
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
    {
      ViewData["ReturnUrl"] = returnUrl;
      var response = _userRepository.Validate(userName, password);

      if (response.IsSuccess)
      {
        var claims = new List<Claim>()
        {
          new Claim("user", userName),
          new Claim("role", "Member")
        };

        await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));

        if (Url.IsLocalUrl(returnUrl))
        {
          return Redirect(returnUrl);
        }
        else
        {
          return Redirect("/");
        }
      }

      return View(response);
    }

    public IActionResult AccessDenied(string returnUrl = null)
    {
      return View();
    }

    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync();
      return Redirect("/");
    }
  }
}
