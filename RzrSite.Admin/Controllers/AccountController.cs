using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repository;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [HttpGet("[action]")]
    public IActionResult Login(string returnUrl = null)
    {
      return View();
    }

    [HttpPost("[action]")]
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
    
    [HttpGet("[action]")]
    public IActionResult AccessDenied(string returnUrl = null)
    {
      return View();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync();
      return Redirect("/");
    }
  }
}
