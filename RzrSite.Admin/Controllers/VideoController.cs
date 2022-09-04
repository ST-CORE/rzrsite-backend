using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.Video;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  [Route("/category/{categoryId}/productLine/{productLineId}/product/{productId}/[controller]")]
  public class VideoController : Controller
  {
    private readonly IVideoRepository _repo;

    public VideoController(IVideoRepository repo, IProductRepository productRepo)
    {
      _repo = repo;
    }

    [HttpGet("[action]")]
    public IActionResult Add()
    {
      return View(new PostVideo());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(int categoryId, int productLineId, int productId, PostVideo model)
    {
      var response = await _repo.AddVideo(productId, model);
      if (response != null)
      {
        return NavigateBackwards(categoryId, productLineId, productId);
      }

      //TODO: Error handling
      return NavigateBackwards(categoryId, productLineId, productId);
    }

    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Edit(int categoryId, int productLineId, int productId, int id)
    {
      var product = await _repo.GetVideo(productId, id);
      if (product == null)
      {
        //TODO: Error handling
        return NavigateBackwards(categoryId, productLineId, productId);
      }

      return View(product);
    }

    [HttpPost("{id}/[action]")]
    public async Task<IActionResult> Edit(int categoryId, int productLineId, int productId, int id, PutVideo video)
    {
      var response = await _repo.UpdateVideo(productId, id, video);
      if (response == null)
      {
        RedirectToAction("Edit", new { categoryId, productLineId, productId, id });
      }
      return View(response);
    }

    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Delete(int categoryId, int productLineId, int productId, int id)
    {
      var response = await _repo.RemoveVideo(productLineId, id);
      if (response == true)
      {
        return NavigateBackwards(categoryId, productLineId, productId);
      }

      //TODO: Error handling
      return NavigateBackwards(categoryId, productLineId, productId);
    }

    [HttpGet("/[controller]/[action]")]
    public IActionResult NavigateBackwards(int categoryId, int productLineId, int productId)
    {
      return RedirectToAction("Edit", "Product", new { categoryId, productLineId, id = productId});
    }
  }
}