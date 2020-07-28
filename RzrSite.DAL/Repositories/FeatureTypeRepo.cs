using AutoMapper;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.FeatureType.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class FeatureTypeRepo: IFeatureTypeRepo
  {
    private readonly RzrSiteDbContext _ctx;
    private readonly IMapper _mapper;

    public FeatureTypeRepo(RzrSiteDbContext ctx, IMapper mapper)
    {
      _mapper = mapper;
      _ctx = ctx;
    }

    public IFeatureType Get(int id)
    {
      return _ctx.FeatureTypes.Find(id);
    }

    public IEnumerable<IFeatureType> GetAll()
    {
      return _ctx.FeatureTypes.ToList();
    }

    public int? Add(IPostFeatureType featureType)
    {
      var model = _mapper.Map<FeatureType>(featureType);
      var result = _ctx.FeatureTypes.Add(model);
      _ctx.SaveChanges();
      return result.Entity?.Id;
    }

    public IFeatureType Update(int id, IPutFeatureType featureType)
    {
      var entity = _ctx.FeatureTypes.Find(id);
      if (entity == null) return null;
      entity = _mapper.Map(featureType, entity);
      _ctx.FeatureTypes.Update(entity);
      _ctx.SaveChanges();
      return entity;
    }

    public bool Delete(int id)
    {
      if (!_ctx.FeatureTypes.Any(c => c.Id.Equals(id))) return true;
      var featureType = _ctx.FeatureTypes.Find(id);
      
      _ctx.FeatureTypes.Remove(featureType);
      _ctx.SaveChanges();
      return true;
    }

    public bool Exists(int id) => (_ctx.FeatureTypes.Find(id) != null);
  }
}
