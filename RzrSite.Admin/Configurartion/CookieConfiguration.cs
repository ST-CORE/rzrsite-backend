using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace RzrSite.Admin.Configuration
{
  public class CookieConfiguraion: IConfigureNamedOptions<CookieAuthenticationOptions>
  {
    public CookieConfiguraion()
    {

    }

    public void Configure(string name, CookieAuthenticationOptions options)
    {
      // Only configure the schemes you want
      if(name == Startup.CookieScheme)
      {
        // Nothing to do
      };
    }

    public void Configure(CookieAuthenticationOptions options)
      => Configure( Options.DefaultName, options);
  }
}
