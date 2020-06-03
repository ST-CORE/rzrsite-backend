using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.ViewModels.Files;

namespace RzrSite.Admin.ViewComponents
{
  public class AddFileViewComponent:ViewComponent
  {
    AddViewModel Model { get; set; }

    public AddFileViewComponent()
    {
      Model = new AddViewModel();
    }

    public IViewComponentResult Invoke(string backUrl)
    {
      Model = new AddViewModel();
      Model.BackUrl = backUrl;
      return View(Model);
    }
  }
}
