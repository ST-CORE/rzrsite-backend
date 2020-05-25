using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.Advantage;
using RzrSite.Models.Responses.Advantage;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.API.Controllers
{
  [ApiController]

  [Route("api/ProductLine/{productLineId}/Advantage")]
  public class AdvantageController : Controller
  {
    private readonly IMapper _mapper;
    private readonly IAdvantageRepo _repo;
    private readonly IProductLineRepo _productLineRepo;

    public AdvantageController(IAdvantageRepo repo, IProductLineRepo productLineRepo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
      _productLineRepo = productLineRepo;
    }

    [HttpGet]
    public IActionResult GetAdvantages(int productLineId)
    {
      var advantages = _repo.GetAll(productLineId);
      if (advantages == null || !advantages.Any())
      {
        return NoContent();
      }

      return Ok(_mapper.Map<IList<FullAdvantage>>(advantages));
    }

    [HttpGet("{id}")]
    public IActionResult GetAdvantage(int productLineId, int id)
    {
      var productLine = _productLineRepo.Get(productLineId);
      if (productLine == null) return NotFound($"ProductLine :{productLineId}: not found");

      var advantage = _repo.Get(id);
      if (advantage == null) return NoContent();

      return Ok(_mapper.Map<FullAdvantage>(advantage));
    }

    [HttpPost]
    public IActionResult AddAdvantage(int productLineId, PostAdvantage advantage)
    {
      var advantageId = _repo.Add(productLineId, advantage);
      return Ok(new AddedAdvantage(productLineId, advantageId.Value));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAdvantage(int productLineId, int id, PutAdvantage advantage)
    {
      var productLine = _productLineRepo.Get(productLineId);
      if (productLine == null) return NotFound($"ProductLine :{productLineId}: not found");

      var updatedProdLine = _repo.Update(productLineId, id, advantage);

      return Ok(_mapper.Map<FullAdvantage>(updatedProdLine));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAdvantage(int productLineId, int id)
    {
      var deleted = _repo.Delete(productLineId, id);
      if (!deleted)
        return BadRequest($"Failed to delete an Advantage with id :{id}:");

      return Ok();
    }
  }
}