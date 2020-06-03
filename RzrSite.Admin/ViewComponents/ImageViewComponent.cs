using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.Images;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
  public class ImageViewComponent: ViewComponent
  {
    private readonly IImageRepository _repo;

    public ImageViewComponent(IImageRepository repo)
    {
      _repo = repo;
    }

    public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productLineId, int productId)
    {
      var images = await _repo.GetImages(productId);
      var viewModel = new ListViewModel(images, categoryId, productLineId, productId);
      return View(viewModel);
    }
  }
}
