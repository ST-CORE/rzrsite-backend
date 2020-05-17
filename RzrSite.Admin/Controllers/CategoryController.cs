using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.Category;
using RzrSite.Models.Resources.Category;
using RzrSite.Models.Responses.Category;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  [Authorize]
  [Route("[controller]")]
  public class CategoryController: Controller
  {
    private readonly ICategoryRepository _repo;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Index()
    {
      var categories = await _repo.GetCategories();
      return View(new IndexViewModel(categories));
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> Add()
    {
      return View(new StrippedCategory());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(PostCategory model)
    {
      var response = await _repo.AddCategory(model);
      if (response != null)
      {
        return RedirectToAction("Index");
      }

      return await IndexWithError("Wasn't able to add product line :(");
    }

    [HttpGet("[action]/{categoryId}")]
    public async Task<IActionResult> Edit(int categoryId)
    {
      var category = await _repo.GetCategory(categoryId);
      if (category == null)
      {
        return await IndexWithError("Product line is null, beda-beda");
      }

      return View(_mapper.Map<StrippedCategory>(category));
    }

    [HttpPost("[action]/{categoryId}")]
    public async Task<IActionResult> Edit(int categoryId, PutCategory category)
    {
      var response = await _repo.UpdateCategory(categoryId, category);
      return View(response);
    }

    [HttpGet("[action]/{categoryId}")]
    public async Task<IActionResult> Delete(int categoryId)
    {
      var response = await _repo.RemoveCategory(categoryId);
      if (response == true)
      {
        return RedirectToAction("Index");
      }

      return await IndexWithError("Cannot delete :(");
    }

    private async Task<ViewResult> IndexWithError(string error)
    {
      var files = await _repo.GetCategories();
      return View("Index", new IndexViewModel(files, error));
    }
  }
}
