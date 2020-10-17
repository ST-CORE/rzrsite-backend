using AutoMapper;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Product.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class ProductRepo : IProductRepo
  {
    private readonly RzrSiteDbContext _ctx;
    private readonly IMapper _mapper;

    public ProductRepo(RzrSiteDbContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    /// <inheritdoc/>
    public int? Add(int productLineId, IPostProduct product)
    {
      if (!_ctx.ProductLines.Any(c => c.Id == productLineId))
        throw new EntityNotFoundException($"Product Line with :{productLineId}: not found!");

      var model = _mapper.Map<Product>(product);
      model.ProductLineId = productLineId;
      var result = _ctx.Products.Add(model);
      _ctx.SaveChanges();

      return result.Entity?.Id;
    }

    /// <inheritdoc/>
    public bool Delete(int productLineId, int id)
    {
      if (!_ctx.ProductLines.Any(c => c.Id.Equals(productLineId)))
        throw new EntityNotFoundException($"Product Line :{productLineId}: not found");

      if (!_ctx.Products.Any(c => c.Id.Equals(id)))
        throw new EntityNotFoundException($"Product :{id}: not found");

      if (!_ctx.Products.Any(c => c.ProductLineId == productLineId && c.Id == id))
        throw new InconsistentStructureException($"Product :{id}: not found in Product Line :{productLineId}:");

      //TODO: Cleanup advantages/documents

      var product = _ctx.Products.Find(id);
      //foreach (var feat in product.Features)
      //{
      //  //TODO: remove features
      //}

      _ctx.Products.Remove(product);

      _ctx.SaveChanges();
      return true;
    }

    /// <inheritdoc/>
    public IProduct Get(int id)
    {
      if (!_ctx.Products.Any(p => p.Id == id))
        throw new EntityNotFoundException($"Product :{id}: not found!");

      return _ctx.Products.First(p => p.Id == id);
    }

    /// <inheritdoc/>
    public IProduct Get(int productLineId, int id)
    {
      if (!_ctx.ProductLines.Any(c => c.Id == productLineId))
        throw new EntityNotFoundException($"Product line :{productLineId}: not found!");

      if (!_ctx.Products.Any(c => c.Id == id))
        throw new EntityNotFoundException($"Product :{id}: not found!");

      if (!_ctx.Products.Any(c => c.ProductLineId == productLineId && c.Id == id))
        throw new InconsistentStructureException($"Product :{id}: not found in Product Line :{productLineId}:");

      return _ctx.Products.First(p => p.Id == id);
    }

    /// <inheritdoc/>
    public IEnumerable<IProduct> GetAll(int productLineId)
    {
      if (!_ctx.ProductLines.Any(c => c.Id == productLineId))
        throw new EntityNotFoundException($"Product line :{productLineId}: not found!");

      return _ctx.Products.Where(p => p.ProductLineId == productLineId).ToList();
    }

    /// <inheritdoc/>
    public IProduct Update(int productLineId, int id, IPutProduct product)
    {
      var entity = _ctx.Products.Find(id);
      if (entity == null) return null;

      if (!_ctx.ProductLines.Any(pl => pl.Id == productLineId))
        throw new EntityNotFoundException($"Product line :{productLineId}: not found!");

      if (!_ctx.Products.Any(c => c.ProductLineId == productLineId && c.Id == id))
        throw new InconsistentStructureException($"Product :{id}: not found in Product Line :{productLineId}:");

      entity = _mapper.Map(product, entity);
      _ctx.Products.Update(entity);

      _ctx.SaveChanges();

      return entity;
    }

    /// <inheritdoc/>
    public bool Exists(int id) => (_ctx.Products.Find(id) != null);
  }
}
