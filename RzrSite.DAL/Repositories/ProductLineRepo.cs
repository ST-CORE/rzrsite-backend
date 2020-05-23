using AutoMapper;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.ProductLine.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class ProductLineRepo: IProductLineRepo
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

      var model = _mapper.Map<ProductLine>(productLine);
      model.CategoryId = categoryId;

      var result = _ctx.ProductLines.Add(model);
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
      
      if(productLine.CategoryId != categoryId)
        throw new InconsistentStructureException($"ProductLine :{id}: is not in category :{categoryId}:");

      if (productLine.Products != null && productLine.Products.Any()) 
        return false;

      //TODO: Cleanup advantages/documents

      _ctx.ProductLines.Remove(productLine);

      _ctx.SaveChanges();
      return true;
    }
  }
}
