using AutoMapper;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Feature.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class FeatureRepo : IFeatureRepo
  {
    private readonly RzrSiteDbContext _ctx;
    private readonly IMapper _mapper;

    public FeatureRepo(RzrSiteDbContext ctx, IMapper mapper)
    {
      _mapper = mapper;
      _ctx = ctx;
    }

    /// <inheritdoc/>
    public int? Add(int productId, IPostFeature feature)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      var model = _mapper.Map<Feature>(feature);
      model.ProductId = productId;
      var result = _ctx.Features.Add(model);
      _ctx.SaveChanges();

      return result.Entity?.Id;
    }

    public bool Delete(int productId, int id)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      if (!_ctx.Features.Any(f => f.Id == id && f.ProductId == productId))
        throw new InconsistentStructureException($"Product :{productId}: doesn't contain feature :{id}:");

      var feature = _ctx.Features.Find(id);

      _ctx.Features.Remove(feature);
      _ctx.SaveChanges();

      return true;
    }

    public IFeature Get(int productId, int id)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      if (!_ctx.Features.Any(f => f.Id == id && f.ProductId == productId))
        throw new InconsistentStructureException($"Product :{productId}: doesn't contain feature :{id}:");

      return _ctx.Features.Find(id);
    }

    public IEnumerable<IFeature> GetAll(int productId)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      return _ctx.Features.Where(f => f.ProductId == productId).ToList();
    }

    public IFeature Update(int productId, int id, IPutFeature feature)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      if (!_ctx.Features.Any(f => f.Id == id && f.ProductId == productId))
        throw new InconsistentStructureException($"Product :{productId}: doesn't contain feature :{id}:");

      var model = _ctx.Features.Find(id);
      model = _mapper.Map(feature, model);

      _ctx.Features.Update(model);
      _ctx.SaveChanges();

      return model;
    }
  }
}
