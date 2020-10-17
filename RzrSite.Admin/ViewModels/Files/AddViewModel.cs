using Microsoft.AspNetCore.Http;

namespace RzrSite.Admin.ViewModels.Files
{
  public class AddViewModel
  {
    public IFormFile FormFile { get; set; }
    public string Path { get; set; }
    public string BackUrl { get; set; }
  }
}
