using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.ProductLine;
using RzrSite.Models.Resources.ProductLine;
using RzrSite.Models.Responses.ProductLine;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  [Route("/category/{categoryId}/[controller]")]
  public class ProductLineController : Controller
  {
    private readonly IProductLineRepository _repo;
    private readonly IMapper _mapper;
    public ProductLineController(IProductLineRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet("[action]")]
    public IActionResult Add(int categoryId)
    {
      return View(new PostProductLine());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(int categoryId, PostProductLine model)
    {
      var response = await _repo.AddProductLine(categoryId, model);
      if (response != null)
      {
        return RedirectToAction("Edit", "Category", new { categoryId });
      }

      //TODO: Error handling
      return RedirectToAction("Edit", "Category", new { categoryId });
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Edit(int categoryId, int id)
    {
      var productLine = await _repo.GetProductLine(categoryId, id);
      if (productLine == null)
      {
        //TODO: Error handling
        return RedirectToAction("Edit", "Category", new { categoryId });
      }

      return View(_mapper.Map<StrippedProductLine>(productLine));
    }

    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Edit(int categoryId, int id, PutProductLine productLine)
    {
      var response = await _repo.UpdateProductLine(categoryId, id, productLine);
      return View(response);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Delete(int categoryId, int id)
    {
      var response = await _repo.RemoveProductLine(categoryId, id);
      if (response == true)
      {
        return RedirectToAction("Edit", "Category", new { categoryId });
      }

      //TODO: Error handling
      return RedirectToAction("Edit", "Category", new { categoryId });
    }

    [HttpGet("[action]")]
    public IActionResult NavigateBackwards(int categoryId)
    {
      return RedirectToAction("Edit", "Category", new { categoryId });
    }
  }
}
