using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.Product;
using RzrSite.Models.Responses.Product;

namespace RzrSite.API.Controllers
{
  [ApiController]
  [Route("api/Category/{categoryId}/ProductLine/{productLineId}/Product")]
  public class ProductController : Controller
  {
    private readonly IProductRepo _repo;
    private readonly ICategoryRepo _categoryRepo;

    public ProductController(IProductRepo repo, ICategoryRepo categoryRepo)
    {
      _repo = repo;
      _categoryRepo = categoryRepo;
    }

    [HttpGet("/api/[controller]/{id}")]
    public IActionResult GetDirectProduct(int id)
    {
      var product = _repo.Get(id);

      if (product == null)
      {
        return NoContent();
      }

      return Ok(product);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int categoryId, int productLineid, int id)
    {
      var category = _categoryRepo.Get(categoryId);
      if (!category.ProductLines.Any(p => p.Id == productLineid))
        return BadRequest($"Category :{categoryId}: doesn't contain Product Line :productLineId:");

      var product = _repo.Get(productLineid, id);

      if (product == null)
      {
        return NoContent();
      }

      return Ok(product);
    }

    [HttpGet]
    public IActionResult GetProducts(int categoryId, int productLineId)
    {
      var category = _categoryRepo.Get(categoryId);
      if (category == null) return NotFound($"Category :{categoryId}: not found");

      if (category.ProductLines != null && !category.ProductLines.Any(pl => pl.Id == productLineId))
        throw new InconsistentStructureException($"ProductLine :{productLineId}: not found in Category :{categoryId}:");

      var products = _repo.GetAll(productLineId);

      if (products == null || !products.Any())
        return NoContent();

      return Ok(products.ToList());
    }

    [HttpPost]
    public IActionResult AddProduct(int categoryId, int productLineId, PostProduct product)
    {
      var category = _categoryRepo.Get(categoryId);
      if (category == null) return NotFound($"Category :{categoryId}: not found");

      if (category.ProductLines!=null && !category.ProductLines.Any(pl => pl.Id == productLineId))
        throw new InconsistentStructureException($"ProductLine :{productLineId}: not found in Category :{categoryId}:");

      var prodId = _repo.Add(productLineId, product);
      return Ok(new AddedProduct(categoryId, prodId.Value));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int categoryId, int productLineId, int id, PutProduct product)
    {
      var category = _categoryRepo.Get(categoryId);
      if (category == null) return NotFound($"Category :{categoryId}: not found");

      if (category.ProductLines != null && !category.ProductLines.Any(pl => pl.Id == productLineId))
        throw new InconsistentStructureException($"ProductLine :{productLineId}: not found in Category :{categoryId}:");

      var updatedProduct = _repo.Update(productLineId, id, product);

      return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int categoryId, int productLineId, int id)
    {
      var category = _categoryRepo.Get(categoryId);
      if (category == null) return NotFound($"Category :{categoryId}: not found");

      if (category.ProductLines != null && !category.ProductLines.Any(pl => pl.Id == productLineId))
        throw new InconsistentStructureException($"ProductLine :{productLineId}: not found in Category :{categoryId}:");

      var deleted = _repo.Delete(productLineId, id);
      if (!deleted)
        return BadRequest($"Failed to delete a Product :{id}: :(");

      return Ok();
    }
  }
}