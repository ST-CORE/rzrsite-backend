using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Interfaces;

namespace RzrSite.API.Controllers
{
  [ApiController]

  [Route("api/[controller]")]
  public class CategoryController : ControllerBase
  {
    private ICategoryRepo _repo;


    public CategoryController(ICategoryRepo repo)
    {
      _repo = repo;
    }

    /// <summary>
    /// Retrieves all categories from the DB
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetCategories()
    {
      var categories = _repo.GetCategories();
      if(categories == null)
      {
        return NotFound();
      }

      return Ok(categories);
    }
  }
}