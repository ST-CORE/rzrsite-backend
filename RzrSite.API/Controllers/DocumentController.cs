using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.Documents;
using RzrSite.Models.Responses.Documents;
using System.Linq;
using System.Threading.Tasks;

namespace RzrSite.API.Controllers
{
    [ApiController]
    [Route("api/Document")]
    public class DocumentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductLineRepo _productLineRepo;
        private readonly IDbFileRepo _dbFileRepo;

        public DocumentController(IMapper mapper, IProductLineRepo productLineRepo, IDbFileRepo dbFileRepo)
        {
            _mapper = mapper;
            _productLineRepo = productLineRepo;
            _dbFileRepo = dbFileRepo;
        }
        
        [HttpPost("/api/document/add")]
        public async Task<IActionResult> Add(PostDocument model)
        {
            await _productLineRepo.AddDocument(model.ProductLineId, model.FileId, model.Description, model.Weight);
            return Ok("Ok");
        }


        [HttpPut("/api/document/edit")]
        public async Task<IActionResult> Edit(PutDocument model)
        {
            await _productLineRepo.UpdateDocument(model.Id, model.Description, model.Weight);
            return Ok("Ok");
        }

        [HttpGet("/api/document/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var document = await _productLineRepo.GetDocument(id);
            return Ok(document);
        }

        [HttpDelete("/api/document/delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _productLineRepo.DeleteDocument(id);
            return Ok("Ok");
        }

        [HttpGet("/api/document/product-line/{id}")]
        public IActionResult GetProductDocuments(int id)
        {
            var documents = _productLineRepo.GetDocuments(id);
            var model = documents.Select(_mapper.Map<ProductLineDocumentResponse>).ToList();
            foreach (var item in model)
            {
                var file = _dbFileRepo.Get(item.FileId);
                item.FilePath = file?.Path;
            }
            return Ok(model);
        }
    }
}
