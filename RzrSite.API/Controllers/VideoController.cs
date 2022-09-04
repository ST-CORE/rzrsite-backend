using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.Video;
using RzrSite.Models.Responses.Video;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.API.Controllers
{
    [ApiController]
    [Route("api/Product/{productId}")]
    public class VideoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepo _repo;
        private readonly IProductRepo _productRepo;

        public VideoController(IVideoRepo repo, IProductRepo productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _productRepo = productRepo;
        }

        [HttpGet("Video")]
        public IActionResult GetVideos(int productId)
        {
            var videos = _repo.GetAll(productId);
            if (videos == null || !videos.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IList<FullVideo>>(videos));
        }

        [HttpGet("Video/{id}")]
        public IActionResult GetVideo(int productId, int id)
        {
            var product = _productRepo.Get(productId);
            if (product == null) return NotFound($"Product :{productId}: not found");

            var video = _repo.Get(id);
            if (video == null) return NoContent();

            return Ok(_mapper.Map<FullVideo>(video));
        }

        [HttpPost("Video")]
        public IActionResult AddVideo(int productId, PostVideo video)
        {
            var videoId = _repo.Add(productId, video);
            return Ok(new AddedVideo(productId, videoId.Value));
        }

        [HttpPut("Video/{id}")]
        public IActionResult UpdateVideo(int productId, int id, PutVideo video)
        {
            var productLine = _productRepo.Get(productId);
            if (productLine == null) return NotFound($"Product :{productId}: not found");

            var updatedVideo = _repo.Update(productId, id, video);

            return Ok(_mapper.Map<FullVideo>(updatedVideo));
        }

        [HttpDelete("Video/{id}")]
        public IActionResult DeleteAdvantage(int productId, int id)
        {
            var deleted = _repo.Delete(productId, id);
            if (!deleted)
                return BadRequest($"Failed to delete an Video with id :{id}:");

            return Ok();
        }
    }
}
