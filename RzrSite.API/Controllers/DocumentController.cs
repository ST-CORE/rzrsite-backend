using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.Documents;

namespace RzrSite.API.Controllers
{
    [ApiController]
    [Route("api/Document")]
    public class DocumentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductLineRepo _productLineRepo;

        public DocumentController(IMapper mapper, IProductLineRepo productLineRepo)
        {
            _mapper = mapper;
            _productLineRepo = productLineRepo;
        }



        [HttpPost("Add")]
        public IActionResult AddImage(PostDocument model)
        {
            //todo: сохранить документ
            return Ok();
        }

    }
}
