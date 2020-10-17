using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.Image;
using RzrSite.Models.Responses.Image;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.API.Controllers
{
    [ApiController]
    [Route("api/Product/{productId}")]
    public class ImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageRepo _repo;
        private readonly IProductRepo _productRepo;

        public ImageController(IImageRepo repo, IProductRepo productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _productRepo = productRepo;
        }

        [HttpGet("Image")]
        public IActionResult GetImages(int productId)
        {
            var images = _repo.GetAll(productId);
            if (images == null || !images.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IList<FullImage>>(images));
        }

        [HttpGet("Image/{id}")]
        public IActionResult GetImage(int productId, int id)
        {
            var product = _repo.Get(productId);
            if (product == null) return NotFound($"Product :{productId}: not found");

            var image = _repo.Get(id);
            if (image == null) return NoContent();

            return Ok(_mapper.Map<FullImage>(image));
        }

        [HttpPost("Image")]
        public IActionResult AddImage(int productId, PostImage advantage)
        {
            var imageId = _repo.Add(productId, advantage);
            return Ok(new AddedImage(productId, imageId.Value));
        }

        [HttpPut("Image/{id}")]
        public IActionResult UpdateImage(int productId, int id, PutImage image)
        {
            var productLine = _productRepo.Get(productId);
            if (productLine == null) return NotFound($"Product :{productId}: not found");

            var updatedImage = _repo.Update(productId, id, image);

            return Ok(_mapper.Map<FullImage>(updatedImage));
        }

        [HttpDelete("Image/{id}")]
        public IActionResult DeleteAdvantage(int productId, int id)
        {
            var deleted = _repo.Delete(productId, id);
            if (!deleted)
                return BadRequest($"Failed to delete an Image with id :{id}:");

            return Ok();
        }
    }
}
