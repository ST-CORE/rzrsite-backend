using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.FeatureType;
using RzrSite.Models.Responses.FeatureType;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.API.Controllers
{
    [Route("/api/Category/{categoryId}/FeatureType")]
    public class FeatureTypeController : Controller
    {
        private readonly IFeatureTypeRepo _repo;
        private readonly IMapper _mapper;

        public FeatureTypeController(IFeatureTypeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var featureType = _repo.Get(id);
            if (featureType == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<FeatureType>(featureType));
        }

        [HttpGet]
        public IActionResult GetAll(int categoryId)
        {
            var featureTypes = _repo.GetAll(categoryId);
            if (featureTypes == null || !featureTypes.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IList<FeatureType>>(featureTypes));
        }

        [HttpPost]
        public IActionResult Add(int categoryId, [FromBody] PostFeatureType model)
        {
            var featureTypeId = _repo.Add(categoryId, model);
            if (!featureTypeId.HasValue)
            {
                return Problem("Unable to add feature type into the DB");
            }

            return Ok(new AddedFeatureType(featureTypeId.Value));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PutFeatureType model)
        {
            var found = _repo.Get(id) != null;
            if (!found) return NotFound();

            var featureType = _repo.Update(id, model);

            return Ok(featureType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int categoryId, int id)
        {
            //Check if empty
            var deleted = _repo.Delete(id);
            if (!deleted)
            {
                return BadRequest("Failed to delete a feature type. Need to look logs, I guess");
            }

            return Ok();
        }
    }
}
