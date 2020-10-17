using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Consts;
using RzrSite.Admin.Repository;
using RzrSite.Admin.ViewModels.Files;
using RzrSite.Models.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
  public class FileSelectViewComponent:ViewComponent
  {
    private readonly IDbFileRepository _repo;

    public FileSelectViewComponent(IDbFileRepository repo)
    {
      _repo = repo;
    }

    public async Task<IViewComponentResult> InvokeAsync(string fileType, string firstButtonPrefix, string secondButtonPrefix)
    {
      var products = await _repo.GetFileList();
      switch (fileType)
      {
        case FileTypeConst.Image:
          products = products.Where(p => p.Format == FileFormat.Png || p.Format == FileFormat.Jpg).ToList();
          break;
      }
      var viewModel = new SelectViewModel(products, firstButtonPrefix, secondButtonPrefix);
      if (!string.IsNullOrWhiteSpace(secondButtonPrefix))
      {
        return View("TwoButton", viewModel);
      }
      return View(viewModel);
    }

  }
}
