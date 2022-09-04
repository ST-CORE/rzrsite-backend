using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Video.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class VideoRepo : IVideoRepo
  {
    private readonly RzrSiteDbContext _ctx;
    private readonly IMapper _mapper;

    public VideoRepo(RzrSiteDbContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    public int? Add(int productId, IPostVideo video)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      var model = _mapper.Map<Video>(video);
      var result = _ctx.Videos.Add(model);
      _ctx.SaveChanges();

      var product = _ctx.Products
          .Include(p => p.Videos)
          .First(p => p.Id == productId);

      if(product.Videos == null)
      {
        product.Videos = new List<IVideo>();
      }

      product.Videos.Add(result.Entity);
      _ctx.SaveChanges();
      
      return result.Entity?.Id;
    }

    public bool Delete(int productId, int id)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      if (!_ctx.Videos.Any(c => c.Id == id))
        throw new EntityNotFoundException($"Video :{id}: not found!");

      if (!_ctx.Products.Include(p => p.Videos).Any(a => a.Id == productId && a.Videos.Any(i => i.Id == id)))
        throw new InconsistentStructureException($"Product :{productId}: doesn't contain Video :{id}:");

      var model = _ctx.Videos.Find(id);

      _ctx.Videos.Remove(model);

      return true;
    }

    public IVideo Get(int id)
    {
      if (!_ctx.Videos.Any(c => c.Id == id))
        throw new EntityNotFoundException($"Video :{id}: not found!");

      var result = _ctx.Videos
        .First(i => i.Id == id);

      return result;
    }

    public IEnumerable<IVideo> GetAll(int productId)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      var result = _ctx.Products
        .Include(p => p.Videos)
        .First(a => a.Id == productId)
        .Videos;

      return result;
    }

    public IVideo Update(int productId, int id, IPutVideo video)
    {
      var entity = _ctx.Videos.Find(id);
      if (entity == null) return null;

      if (!_ctx.Products.Any(p => p.Id == productId) || !_ctx.Products.Include(p => p.Videos).Any(p => p.Videos.Any(i => i.Id == id)))
        throw new InconsistentStructureException($"Video :{id}: is not in Product :{productId}:");

      entity = _mapper.Map(video, entity);
      _ctx.Videos.Update(entity);
      _ctx.SaveChanges();

      return entity;
    }
  }
}
