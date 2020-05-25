using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.Advantage;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{

  [Route("/category/{categoryId}/productLine/{productLineId}/[controller]")]
  public class AdvantageController : Controller
  {
    private readonly IAdvantageRepository _repo;

    public AdvantageController(IAdvantageRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("[action]")]
    public IActionResult Add(int categoryId, int productLineId, int id)
    {
      return View(new PostAdvantage());
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(int categoryId, int productLineId, int id, PostAdvantage model)
    {
      var response = await _repo.AddAdvantage(productLineId, model);
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
      var product = await _repo.GetAdvantage(productLineId, id);
      if (product == null)
      {
        //TODO: Error handling
        return NavigateBackwards(categoryId, productLineId);
      }

      return View(product);
    }

    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Edit(int categoryId, int productLineId, int id, PutAdvantage product)
    {
      var response = await _repo.UpdateAdvantage(productLineId, id, product);
      if(response == null)
      {
        RedirectToAction("Edit", new { categoryId, productLineId, id });
      }
      return View(response);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Delete(int categoryId, int productLineId, int id)
    {
      var response = await _repo.RemoveAdvantage(productLineId, id);
      if (response == true)
      {
        return NavigateBackwards(categoryId, productLineId);
      }

      //TODO: Error handling
      return NavigateBackwards(categoryId, productLineId);
    }

    [HttpGet("{id}/[action]/{fileId}")]
    public async Task<IActionResult> AssignFile(int categoryId, int productLineId, int id, int fileId)
    {
      var putModel = new PutAdvantage
      {
        IconId = fileId
      };

      await _repo.UpdateAdvantage(productLineId, id, putModel);

      return RedirectToAction("Edit", "Advantage", new { categoryId, productLineId, id });
    }
    
    [HttpGet("/[controller]/[action]")]
    public IActionResult NavigateBackwards(int categoryId, int productLineId)
    {
      return RedirectToAction("Edit", "ProductLine", new { categoryId, id = productLineId });
    }
  }
}