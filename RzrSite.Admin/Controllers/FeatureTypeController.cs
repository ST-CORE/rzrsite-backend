using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.FeatureType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  [Authorize]
  [Route("/Category/{categoryId}/[controller]")]
  public class FeatureTypeController: Controller
  {
    IFeatureTypeRepository _fileTypeRepo { get; set; }
    public FeatureTypeController(IFeatureTypeRepository fileTypeRepo)
    {
      _fileTypeRepo = fileTypeRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int categoryId)
    {
      IList<FeatureType> model = await _fileTypeRepo.GetAllFeatureTypes(categoryId);
      if (model == null)
        model = new List<FeatureType>();
      return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(int categoryId, PostFeatureType postModel)
    {
      await _fileTypeRepo.AddFeatureType(categoryId, postModel);
      return RedirectToAction("Index", new { categoryId });
    }

    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Edit(int categoryId, int id)
    {
      var model = await _fileTypeRepo.GetFeatureType(categoryId, id);
      return View(model);
    }


    [HttpPost("{id}/[action]")]
    public async Task<IActionResult> Edit(int categoryId, int id, PutFeatureType putModel)
    {
      var model = await _fileTypeRepo.UpdateFeatureType(categoryId, id, putModel);
      return View(model);
    }


    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Remove(int categoryId, int id)
    {
      await _fileTypeRepo.RemoveFeatureType(categoryId, id);
      return RedirectToAction("Index", new { categoryId });
    }
  }
}
