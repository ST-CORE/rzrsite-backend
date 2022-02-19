using AutoMapper;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.ProductLine.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RzrSite.Models.Responses.ProductLine;

namespace RzrSite.DAL.Repositories
{
  public class ProductLineRepo : IProductLineRepo
  {
	private readonly RzrSiteDbContext _ctx;
	private readonly IMapper _mapper;

	public ProductLineRepo(RzrSiteDbContext ctx, IMapper mapper)
	{
	  _ctx = ctx;
	  _mapper = mapper;
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public IEnumerable<IProductLine> GetAll(int categoryId)
	{
	  if (!_ctx.Categories.Any(c => c.Id == categoryId))
		throw new EntityNotFoundException($"Category with Id = {categoryId} not found!");

	  return _ctx.ProductLines.Where(pl => pl.CategoryId == categoryId).ToList();
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public IProductLine Get(int id)
	{
	  return _ctx.ProductLines.Find(id);
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public IProductLine Update(int categoryId, int id, IPutProductLine productLine)
	{
	  var entity = _ctx.ProductLines.Find(id);
	  if (entity == null) return null;

	  if (entity.CategoryId != categoryId)
		throw new InconsistentStructureException($"ProductLine :{id}: is not in Category :{categoryId}:");

	  entity = _mapper.Map(productLine, entity);
	  
	  if(productLine.FeaturesPDFPath != null)
	  {
		var file = _ctx.Files.FirstOrDefault(f => f.Path.ToLower() == productLine.FeaturesPDFPath.ToLower());
		entity.FeaturesPDF = file;
	  }

	  _ctx.ProductLines.Update(entity);

	  _ctx.SaveChanges();

	  return entity;
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public int? Add(int categoryId, IPostProductLine productLine)
	{
	  if (!_ctx.Categories.Any(c => c.Id == categoryId))
		throw new EntityNotFoundException($"Category with Id = {categoryId} not found!");

	  var entity = _mapper.Map<ProductLine>(productLine);
	  entity.CategoryId = categoryId;

	  var file = _ctx.Files.FirstOrDefault(f => f.Path.ToLower() == productLine.FeaturesPDFPath.ToLower());
	  entity.FeaturesPDF = file;
	  
	  var result = _ctx.ProductLines.Add(entity);
	  _ctx.SaveChanges();

	  return result.Entity?.Id;
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public bool Delete(int categoryId, int id)
	{
	  if (!_ctx.Categories.Any(c => c.Id.Equals(categoryId)))
		throw new EntityNotFoundException($"Category :{categoryId}: not found");

	  if (!_ctx.ProductLines.Any(c => c.Id.Equals(id)))
		throw new EntityNotFoundException($"ProductLine :{id}: not found");

	  var productLine = _ctx.ProductLines.Find(id);

	  if (productLine.CategoryId != categoryId)
		throw new InconsistentStructureException($"ProductLine :{id}: is not in category :{categoryId}:");

	  if (productLine.Products != null && productLine.Products.Any())
		return false;

	  //TODO: Cleanup advantages/documents

	  _ctx.ProductLines.Remove(productLine);

	  _ctx.SaveChanges();
	  return true;
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
  	public bool Exists(int id) => (_ctx.ProductLines.Where(pl => pl.Id == id) != null);

	public List<ProductLineDocument> GetDocuments(int productLineId)
	{
	  var productLine = _ctx.ProductLines.Include(x => x.Documents).FirstOrDefault(x => x.Id == productLineId);
	  return productLine == null ? new List<ProductLineDocument>() : productLine.Documents.Select(x => x as Document).Select(x => new ProductLineDocument
	  {
		Weight = x?.Weight ?? 0,
		Description = x?.Description,
		Id = x?.Id ?? 0,
		FileId = x?.FileId ?? 0
	  }).ToList();
	}

	/// <summary>
	/// Adds new document
	/// </summary>
	/// <param name="productLineId">Id of product line</param>
	/// <param name="fileId">Id of new document</param>
	/// <param name="description">Description of new document</param>
	/// <param name="weight">Weight for sorting</param>
	/// <returns></returns>
	public async Task AddDocument(int productLineId, int fileId, string description, int weight)
	{
	  var productLine = await _ctx.ProductLines.FirstOrDefaultAsync(x => x.Id == productLineId);
	  if (productLine == null) return;

	  productLine.Documents.Add(new Document
	  {
		FileId = fileId,
		Weight = weight,
		Description = description
	  });

	  await _ctx.SaveChangesAsync();
	}

	/// <summary>
	/// Обновить документ
	/// </summary>
	/// <param name="id"></param>
	/// <param name="description"></param>
	/// <param name="weight"></param>
	/// <returns></returns>
	public async Task UpdateDocument(int id, string description, int weight)
	{
	  var document = await _ctx.Documents.FirstOrDefaultAsync(x => x.Id == id);

	  if (document == null) return;

	  document.Description = description;
	  document.Weight = weight;

	  await _ctx.SaveChangesAsync();
	}

	public async Task<Document> GetDocument(int id)
	{
	  var document = await _ctx.Documents.FirstOrDefaultAsync(x => x.Id == id);
	  return document;
	}

	public async Task DeleteDocument(int id)
	{
	  var document = await _ctx.Documents.FirstOrDefaultAsync(x => x.Id == id);
	  if (document == null) return;
	  _ctx.Documents.Remove(document);
	  await _ctx.SaveChangesAsync();
	}

	public async Task SetShowOnMain(int productLineId)
	{
	  var productLine = await _ctx.ProductLines.FirstOrDefaultAsync(x => x.Id == productLineId);
	  if (productLine == null) return;

	  var lines = await _ctx.ProductLines.Where(x => x.CategoryId == productLine.CategoryId).ToListAsync();
	  foreach (var line in lines) line.IsShowOnMain = false;
	  productLine.IsShowOnMain = true;

	  await _ctx.SaveChangesAsync();
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public ProductLineDocument GetFeaturesPDF(int productLineId)
	{
	  var productLine = _ctx.ProductLines.Include(x => x.FeaturesPDF).FirstOrDefault(x => x.Id == productLineId);
	  var pdf = productLine.FeaturesPDF;

	  if (pdf == null)
	  {
		return null;
	  }

	  return new ProductLineDocument
	  {
		Weight = 0,
		Description = "Документ, описывающий технические характеристики продукта",
		Id = pdf.Id,
		FileId = pdf.Id
	  };
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public ProductLineDocument SetAsFeaturesPDF(int productLineId, int fileId)
	{

	  var productLine = _ctx.ProductLines.Include(x => x.FeaturesPDF).FirstOrDefault(x => x.Id == productLineId);

	  if (productLine.FeaturesPDF != null)
	  {
		productLine.FeaturesPDF = null;
	  }

	  var file = _ctx.Files.FirstOrDefault(x => x.Id == fileId);

	  if (file == null)
		return null;

	  productLine.FeaturesPDF = file;

	  return new ProductLineDocument
	  {
		FileId = fileId,
		FilePath = file.Path,
		Description = "Документ, описывающий характеристики продукта",
		Weight = 0
	  };
	}
  }
}