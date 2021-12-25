using AutoMapper;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Advantage.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class AdvantageRepo : IAdvantageRepo
  {
    private readonly RzrSiteDbContext _ctx;
    private readonly IMapper _mapper;

    public AdvantageRepo(RzrSiteDbContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    public int? Add(int productLineId, IPostAdvantage advantage)
    {
      if (!_ctx.ProductLines.Any(c => c.Id == productLineId))
        throw new EntityNotFoundException($"Product Line :{productLineId}: not found!");

      var model = _mapper.Map<Advantage>(advantage);
      model.ProductLineId = productLineId;

      var result = _ctx.Advantages.Add(model);
      _ctx.SaveChanges();

      return result.Entity?.Id;
    }

    public bool Delete(int productLineId, int id)
    {
      if (!_ctx.ProductLines.Any(c => c.Id == productLineId))
        throw new EntityNotFoundException($"Product Line :{productLineId}: not found!");

      if (!_ctx.Advantages.Any(c => c.Id == id))
        throw new EntityNotFoundException($"Advantage :{id}: not found!");

      if (!_ctx.Advantages.Any(a => a.Id == id && a.ProductLineId == productLineId))
        throw new InconsistentStructureException($"Product Line :{productLineId}: doesn't contain Advantage :{id}:");

      var model = _ctx.Advantages.Find(id);

      _ctx.Advantages.Remove(model);
      _ctx.SaveChanges();
      return true;
    }

    public IAdvantage Get(int id)
    {
      if (!_ctx.Advantages.Any(c => c.Id == id))
        throw new EntityNotFoundException($"Advantage :{id}: not found!");

      var result = _ctx.Advantages.Find(id);
      if (result.IconId != null && _ctx.Files.Any(f => f.Id == result.IconId))
      {
        result.Icon = _ctx.Files.Find(result.IconId);
      }
      return result;
    }

    public IEnumerable<IAdvantage> GetAll(int productLineId)
    {
      if (!_ctx.ProductLines.Any(c => c.Id == productLineId))
        throw new EntityNotFoundException($"Product Line :{productLineId}: not found!");

      var result = _ctx.Advantages.Where(a => a.ProductLineId == productLineId).ToList();

      foreach(var adv in result)
      {
        adv.Icon = _ctx.Files.Find(adv.IconId);
      }

      return result;
    }

    public IAdvantage Update(int productLineId, int id, IPutAdvantage advantage)
    {
      var entity = _ctx.Advantages.Find(id);
      if (entity == null) return null;

      if (entity.ProductLineId != productLineId)
        throw new InconsistentStructureException($"Advantage :{id}: is not in ProductLine :{productLineId}:");

      entity = _mapper.Map(advantage, entity);
      _ctx.Advantages.Update(entity);
      _ctx.SaveChanges();


      entity.Icon = _ctx.Files.Find(entity.IconId);
      return entity;
    }
  }
}
