using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.ProductContent;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
  public class ProductContentViewComponent: ViewComponent
  {
    private readonly IImageRepository _imageRepo;
		private readonly IVideoRepository _videoRepo;

		public ProductContentViewComponent(IImageRepository imageRepo, IVideoRepository videoRepo)
    {
      _imageRepo = imageRepo;
      _videoRepo = videoRepo;
    }

    public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productLineId, int productId)
    {
      var images = await _imageRepo.GetImages(productId);
			var videos = await _videoRepo.GetVideos(productId);
			var viewModel = new ListViewModel(images, videos, categoryId, productLineId, productId);
      return View(viewModel);
    }
  }
}
