using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.Image;
using RzrSite.Models.Resources.Product;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  [Route("/category/{categoryId}/productLine/{productLineId}/product/{productId}/[controller]")]
  public class ImageController : Controller
  {
    private readonly IImageRepository _repo;
    private readonly IProductRepository _productRepo;

    public ImageController(IImageRepository repo, IProductRepository productRepo)
    {
      _repo = repo;
      _productRepo = productRepo;
    }

    [HttpGet("[action]")]
    public IActionResult Add(int categoryId, int productLineId, int productId, int id)
    {
      return View(new PostImage());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(int categoryId, int productLineId, int productId, PostImage model)
    {
      var response = await _repo.AddImage(productId, model);
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
      var product = await _repo.GetImage(productId, id);
      if (product == null)
      {
        //TODO: Error handling
        return NavigateBackwards(categoryId, productLineId, productId);
      }

      return View(product);
    }

    [HttpPost("{id}/[action]")]
    public async Task<IActionResult> Edit(int categoryId, int productLineId, int productId, int id, PutImage image)
    {
      var response = await _repo.UpdateImage(productId, id, image);
      if (response == null)
      {
        RedirectToAction("Edit", new { categoryId, productLineId, productId, id });
      }
      return View(response);
    }

    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Delete(int categoryId, int productLineId, int productId, int id)
    {
      var response = await _repo.RemoveImage(productLineId, id);
      if (response == true)
      {
        return NavigateBackwards(categoryId, productLineId, productId);
      }

      //TODO: Error handling
      return NavigateBackwards(categoryId, productLineId, productId);
    }

    [HttpGet("{id}/[action]/{fileId}")]
    public async Task<IActionResult> AssignFull(int categoryId, int productLineId, int productId, int id, int fileId)
    {
      var putModel = new PutImage
      {
        FullId = fileId
      };

      await _repo.UpdateImage(productId, id, putModel);

      return RedirectToAction("Edit", "Product", new { categoryId, productLineId, id = productId });
    }

    [HttpGet("{id}/[action]/{fileId}")]
    public async Task<IActionResult> AssignThumb(int categoryId, int productLineId, int productId, int id, int fileId)
    {
      var putModel = new PutImage
      {
        ThumbId = fileId
      };

      await _repo.UpdateImage(productId, id, putModel);

      return RedirectToAction("Edit", "Product", new { categoryId, productLineId, id = productId });
    }

    [HttpGet("/[controller]/[action]")]
    public IActionResult NavigateBackwards(int categoryId, int productLineId, int productId)
    {
      return RedirectToAction("Edit", "Product", new { categoryId, productLineId, id = productId});
    }
  }
}