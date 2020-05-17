using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.Category;
using RzrSite.Models.Responses.Category;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.API.Controllers
{
  [ApiController]

  [Route("/api/category")]
  public class CategoryController : ControllerBase
  {
    private ICategoryRepo _repo;
    private IMapper _mapper;

    public CategoryController(ICategoryRepo repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
      var categories = _repo.GetAll();
      if (categories == null || !categories.Any())
      {
        return NoContent();
      }

      return Ok(_mapper.Map<IList<StrippedCategory>>(categories));
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
      var category = _repo.Get(id);
      if (category == null)
      {
        return NoContent();
      }

      return Ok(_mapper.Map<FullCategory>(category));
    }

    [HttpPost]
    public IActionResult AddCategory(PostCategory category)
    {
      var categoryId = _repo.Add(category);
      if (!categoryId.HasValue)
      {
        return Problem("Unable to add category into the DB");
      }

      return Ok(new AddedCategory(categoryId.Value));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, PutCategory category)
    {
      var found = _repo.Get(id) != null;
      if (!found) return NotFound();

      var categories = _repo.Update(id, category);

      return Ok(_mapper.Map<StrippedCategory>(categories));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
      //Check if empty
      var deleted = _repo.Delete(id);
      if (!deleted)
      {
        return BadRequest("Failed to delete a category. Make sure it doesn't contain any series");
      }

      return Ok();
    }
  }
}