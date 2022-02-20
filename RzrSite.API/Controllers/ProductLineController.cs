using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.DbFile;
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
	private readonly IDbFileRepo _fileRepo;

	public ProductLineController(IProductLineRepo repo, ICategoryRepo categoryRepo, IDbFileRepo fileRepo, IMapper mapper)
	{
	  _mapper = mapper;
	  _repo = repo;
	  _categoryRepo = categoryRepo;
	  _fileRepo = fileRepo;
	}

	[HttpGet]
	public IActionResult GetProductLines(int categoryId)
	{
	  var prodLines = _repo.GetAll(categoryId);
	  if (prodLines == null || !prodLines.Any())
	  {
		return NoContent();
	  }

	  var viewModel = _mapper.Map<IList<StrippedProductLine>>(prodLines);

	  foreach(var pl in viewModel)
	  {
		pl.FeaturesPDFPath = _repo.GetFeaturesPDF(pl.Id).Path;
	  }

	  return Ok(viewModel);
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
	  var fullProdLine = _mapper.Map<FullProductLine>(prodLine);
	  var featuresPdf = _repo.GetFeaturesPDF(fullProdLine.Id);

	  fullProdLine.FeaturesPDF = _mapper.Map<StrippedDbFile>(featuresPdf);

	  return Ok(fullProdLine);
	}

	[HttpPost]
	public async Task<IActionResult> AddProductLine(int categoryId, PostProductLine prodLine)
	{
	  var prodLineId = _repo.Add(categoryId, prodLine);
	  if (prodLineId.HasValue && prodLine.IsShowOnMain) await _repo.SetShowOnMain(prodLineId.Value);

	  var pdfFile = _fileRepo.Get(prodLine.FeaturesPDFPath);
	  
	  if(pdfFile == null)
		throw new InconsistentStructureException($"File with path :{prodLine.FeaturesPDFPath}: not found in storage");

	  _repo.SetAsFeaturesPDF(prodLineId.Value, pdfFile.Id);

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

	[HttpGet("{id}/featurespdf")]
	public IActionResult GetProductLineFeaturesPdf(int categoryId, int id)
	{
	  var category = _categoryRepo.Get(categoryId);
	  if (category == null) return NotFound($"Category :{categoryId}: not found");

	  var prodLine = _repo.Get(id);
	  if (prodLine == null) return NoContent();

	  if (prodLine.CategoryId != categoryId)
		throw new InconsistentStructureException($"ProductLine :{id}: not found in Category :{categoryId}:");

	  var featuresPdf = _mapper.Map<StrippedDbFile>(_repo.GetFeaturesPDF(id));

	  return Ok(featuresPdf);
	}

	[HttpGet("{id}/showonmain")]
	public async Task<IActionResult> ShowOnMain(int productLineId)
	{
	  await _repo.SetShowOnMain(productLineId);
	  return Ok();
	}
  }
}