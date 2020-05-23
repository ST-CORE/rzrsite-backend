using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Product;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  [Route("/category/{categoryId}/productLine/{productLineId}/[controller]")]
  public class ProductController : Controller
  {
    private readonly IProductRepository _repo;

    public ProductController(IProductRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("[action]")]
    public IActionResult Add(int categoryId, int productLineId)
    {
      return View(new PostProduct());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(int categoryId, int productLineId, PostProduct model)
    {
      var response = await _repo.AddProduct(categoryId, productLineId, model);
      if (response != null)
      {
        return NavigateBackwards(categoryId, productLineId);
      }

      //TODO: Error handling
      return NavigateBackwards(categoryId, productLineId);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Edit(int categoryId, int productLineId, int id)
    {
      var product = await _repo.GetProduct(categoryId, productLineId, id);
      if (product == null)
      {
        //TODO: Error handling
        return NavigateBackwards(categoryId, productLineId);
      }

      return View(product);
    }

    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Edit(int categoryId, int productLineid, int id, PutProduct product)
    {
      var response = await _repo.UpdateProduct(categoryId, productLineid, id, product);
      return View(response);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Delete(int categoryId, int productLineId, int id)
    {
      var response = await _repo.RemoveProduct(categoryId, productLineId, id);
      if (response == true)
      {
        return NavigateBackwards(categoryId, productLineId);
      }

      //TODO: Error handling
      return NavigateBackwards(categoryId, productLineId);
    }

    [HttpGet("/[controller]/[action]")]
    public IActionResult NavigateBackwards(int categoryId, int productLineId)
    {
      return RedirectToAction("Edit", "ProductLine", new { categoryId, id = productLineId });
    }
  }
}