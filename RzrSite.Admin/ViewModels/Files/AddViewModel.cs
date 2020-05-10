using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace RzrSite.Admin.ViewModels.Files
{
  public class AddViewModel
  {
    public IFormFile FormFile { get; set; }
  }
}
