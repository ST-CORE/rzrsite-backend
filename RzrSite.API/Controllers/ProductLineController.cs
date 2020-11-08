using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.ProductLine;
using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RzrSite.API.Controllers
{
    [ApiController]

    [Route("api/Category/{categoryId}/ProductLine")]
    public class ProductLineController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductLineRepo _repo;
        private readonly ICategoryRepo _categoryRepo;

        public ProductLineController(IProductLineRepo repo, ICategoryRepo categoryRepo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IActionResult GetProductLines(int categoryId)
        {
            var prodLines = _repo.GetAll(categoryId);
            if (prodLines == null || !prodLines.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IList<StrippedProductLine>>(prodLines));
        }

        [HttpGet("{id}")]
        public IActionResult GetProductLine(int categoryId, int id)
        {
            var category = _categoryRepo.Get(categoryId);
            if (category == null) return NotFound($"Category :{categoryId}: not found");

            var prodLine = _repo.Get(id);
            if (prodLine == null) return NoContent();

            if (prodLine.CategoryId != categoryId)
                throw new InconsistentStructureException($"ProductLine :{id}: not found in Category :{categoryId}:");

            return Ok(_mapper.Map<FullProductLine>(prodLine));
        }

        [HttpPost]
        public async Task<IActionResult> AddProductLine(int categoryId, PostProductLine prodLine)
        {
            var prodLineId = _repo.Add(categoryId, prodLine);
            if (prodLineId.HasValue && prodLine.IsShowOnMain) await _repo.SetShowOnMain(prodLineId.Value);
            return Ok(new AddedProductLine(categoryId, prodLineId.Value));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductLine(int categoryId, int id, PutProductLine prodLine)
        {
            var category = _categoryRepo.Get(categoryId);
            if (category == null) return NotFound($"Category :{categoryId}: not found");

            var updatedProdLine = _repo.Update(categoryId, id, prodLine);

            if (prodLine.IsShowOnMain) await _repo.SetShowOnMain(id);

            return Ok(_mapper.Map<StrippedProductLine>(updatedProdLine));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductLine(int categoryId, int id)
        {
            var deleted = _repo.Delete(categoryId, id);
            if (!deleted)
                return BadRequest($"Failed to delete a Product Line with id = {id}. Make sure it doesn't contain any products");

            return Ok();
        }

        [HttpGet("{id}/documents")]
        public IActionResult GetProductLineDocuments(int categoryId, int id)
        {
            var category = _categoryRepo.Get(categoryId);
            if (category == null) return NotFound($"Category :{categoryId}: not found");

            var prodLine = _repo.Get(id);
            if (prodLine == null) return NoContent();

            if (prodLine.CategoryId != categoryId)
                throw new InconsistentStructureException($"ProductLine :{id}: not found in Category :{categoryId}:");

            var documents = _repo.GetDocuments(id);

            return Ok(documents);
        }

        [HttpGet("{id}/showonmain")]
        public async Task<IActionResult> ShowOnMain(int productLineId)
        {
            await _repo.SetShowOnMain(productLineId);
            return Ok();
        }
    }
}