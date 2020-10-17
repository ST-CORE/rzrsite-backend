using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.FeatureGroup;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.API.Controllers
{
  [Route("api/ProductLine/{productLineId}/FeatureGroup")]
  [ApiController]
  public class FeatureGroupController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IFeatureRepo _repo;

    private readonly IFeatureTypeRepo _typeRepo;
    private readonly IProductLineRepo _productLineRepo;
    private readonly IProductRepo _productRepo;

    public FeatureGroupController(IFeatureRepo repo, IFeatureTypeRepo typeRepo, IProductRepo productRepo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;

      _typeRepo = typeRepo;
      _productRepo = productRepo;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int productLineId)
    {
      if (!_productLineRepo.Exists(productLineId))
        return BadRequest($"Product Line :{productLineId}: does not exist");

      var products = _productRepo.GetAll(productLineId);

      if (products == null || !products.Any())
      {
        return NoContent();
      }

      var result = new FeatureGroup
      {
        ProductLineId = productLineId,
        FeatureGroups = new List<FeatureList>()
      };

      foreach(var product in products)
      {
        var featureList = new FeatureList
        {
          ProductId = product.Id,
          ProductName = product.Name
        };

        featureList.Features = product.Features.ToList();

        result.FeatureGroups.Add(featureList);
      }


      return Ok(result);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int productLineId, [FromBody]FeatureGroup model)
    {
      if (!_productLineRepo.Exists(productLineId))
        return BadRequest($"Product Line :{productLineId}: does not exist");

      if(model.ProductLineId != productLineId)
      {
        return BadRequest($"Product Line :{productLineId}: has different Id from {model.ProductLineId}");
      }

      foreach(var productFeatures in model.FeatureGroups)
      {
        
      }

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int productId, int id)
    {
      if (!_productRepo.Exists(productId))
        return BadRequest($"Product :{productId}: does not exist");

      var deleted = _repo.Delete(productId, id);
      if (!deleted)
      {
        return BadRequest("Failed to delete a feature. Need to look logs, I guess");
      }

      return Ok();
    }
  }
}