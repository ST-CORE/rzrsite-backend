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
  [Route("[controller]")]
  public class FeatureTypeController: Controller
  {
    IFeatureTypeRepository _fileTypeRepo { get; set; }
    public FeatureTypeController(IFeatureTypeRepository fileTypeRepo)
    {
      _fileTypeRepo = fileTypeRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      IList<FeatureType> model = await _fileTypeRepo.GetAllFeatureTypes();
      if (model == null)
        model = new List<FeatureType>();
      return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(PostFeatureType postModel)
    {
      await _fileTypeRepo.AddFeatureType(postModel);
      return RedirectToAction("Index");
    }

    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Edit(int id)
    {
      var model = await _fileTypeRepo.GetFeatureType(id);
      return View(model);
    }


    [HttpPost("{id}/[action]")]
    public async Task<IActionResult> Edit(int id, PutFeatureType putModel)
    {
      var model = await _fileTypeRepo.UpdateFeatureType(id, putModel);
      return View(model);
    }


    [HttpGet("{id}/[action]")]
    public async Task<IActionResult> Remove(int id)
    {
      await _fileTypeRepo.RemoveFeatureType(id);
      return RedirectToAction("Index");
    }
  }
}
