using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Feature;
using RzrSite.Models.Responses.Feature;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RzrSite.API.Models;

namespace RzrSite.API.Controllers
{
    [Route("api/Product/{productId}/Feature")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeatureTypeRepo _featureTypeRepo;
        private readonly IFeatureRepo _repo;
        private readonly IProductRepo _productRepo;
        private readonly IProductLineRepo _productLineRepo;

        public FeatureController(IFeatureRepo repo, IFeatureTypeRepo featureTypeRepo, IProductRepo productRepo, IProductLineRepo productLineRepo, IMapper mapper)
        {
            _mapper = mapper;
            _featureTypeRepo = featureTypeRepo;
            _repo = repo;
            _productRepo = productRepo;
            _productLineRepo = productLineRepo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int productId, int id)
        {
            if (!_productRepo.Exists(productId))
                return BadRequest($"Product :{productId}: does not exist");

            var feature = _repo.Get(productId, id);
            if (feature == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<Feature>(feature));
        }

        [HttpGet]
        public IActionResult GetAll(int productId)
        {
            if (!_productRepo.Exists(productId))
                return BadRequest($"Product :{productId}: does not exist");

            var features = _repo.GetAll(productId);
            if (features == null || !features.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IList<Feature>>(features));
        }

        [HttpPost]
        public IActionResult Add(int productId, [FromBody] PostFeature model)
        {
            if (!_productRepo.Exists(productId))
                return BadRequest($"Product :{productId}: does not exist");

            var product = _productRepo.Get(productId);
            var productLine = _productLineRepo.Get(product.ProductLineId);

            if (!_featureTypeRepo.Exists(productLine.CategoryId, model.FeatureTypeId))
                return BadRequest($"Feature Type :{model.FeatureTypeId}: does not exist");

            var featureId = _repo.Add(productId, model);
            if (!featureId.HasValue)
            {
                return Problem($"Unable to add feature to product :{productId}: into the DB");
            }

            return Ok(new AddedFeature(productId, featureId.Value));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int productId, int id, [FromBody] PutFeature model)
        {
            if (!_productRepo.Exists(productId))
                return BadRequest($"Product :{productId}: does not exist");

            var product = _productRepo.Get(productId);
            var productLine = _productLineRepo.Get(product.ProductLineId);

            if (!_featureTypeRepo.Exists(productLine.CategoryId, model.FeatureTypeId))
                return BadRequest($"Feature Type :{model.FeatureTypeId}: does not exist");

            var found = _repo.Get(productId, id, model.FeatureTypeId) != null;
            if (!found) return NotFound();

            var featureType = _repo.Update(productId, id, model);

            return Ok(featureType);
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

        [HttpGet]
        [Route("/api/Category/{categoryId}/getFeatureTable/{productLineId}")]
        public ProductFeatureTableModel GetFeatureTable(int categoryId, int productLineId)
        {
            var featureTypes = _featureTypeRepo.GetAll(categoryId) as List<FeatureType>;

            var products = _mapper.Map<IList<Product>>(_productRepo.GetAll(productLineId));

            var features = new List<Feature>();
            foreach (var product in products)
            {
                if (_repo.GetAll(product.Id) is List<Feature> prodFeatures)
                {
                    features.AddRange(prodFeatures);
                }
            }
            var viewModel = new ProductFeatureTableModel(products, features, featureTypes, productLineId, categoryId);

            return viewModel;
        }
    }
}