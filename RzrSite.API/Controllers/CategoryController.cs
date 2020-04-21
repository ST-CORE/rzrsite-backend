using Microsoft.AspNetCore.Mvc;
using RzrSite.API.Responses.Category;
using RzrSite.DAL.Reposiories.Interfaces;
using RzrSite.Models.Resources.Category;
using System.Linq;

namespace RzrSite.API.Controllers
{
  [ApiController]

  [Route(Consts.Routes.Category)]
  public class CategoryController : ControllerBase
  {
    private ICategoryRepo _repo;


    public CategoryController(ICategoryRepo repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
      var categories = _repo.GetCategories();
      if(categories == null || !categories.Any())
      {
        return NoContent();
      }

      return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
      var category = _repo.GetCategory(id);
      if (category == null)
      {
        return NoContent();
      }

      return Ok(category);
    }

    [HttpPost]
    public IActionResult AddCategory(PostCategory category)
    {
      var categoryId = _repo.AddCategory(category);
      if (!categoryId.HasValue)
      {
        return Problem("Unable to add category into the DB");
      }

      return Ok(new AddedCategory(categoryId.Value));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, PutCategory category)
    {
      var found = _repo.GetCategory(id) != null;
      if (!found) return NotFound();

      var categories = _repo.UpdateCategory(id, category);
      
      return Ok(categories);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
      //Check if empty
      var deleted = _repo.DeleteCategory(id);
      if (!deleted)
      {
        return BadRequest("Failed to delete a category. Make sure it doesn't contain any series");
      }

      return Ok();
    }
  }
}