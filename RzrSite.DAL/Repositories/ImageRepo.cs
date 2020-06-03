using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Image.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class ImageRepo : IImageRepo
  {
    private readonly RzrSiteDbContext _ctx;
    private readonly IMapper _mapper;

    public ImageRepo(RzrSiteDbContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    public int? Add(int productId, IPostImage image)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      var model = _mapper.Map<Image>(image);
      var result = _ctx.Images.Add(model);
      _ctx.SaveChanges();

      var product = _ctx.Products
          .Include(p => p.Images)
          .First(p => p.Id == productId);

      if(product.Images == null)
      {
        product.Images = new List<IImage>();
      }

      product.Images.Add(result.Entity);
      _ctx.SaveChanges();
      
      return result.Entity?.Id;
    }

    public bool Delete(int productId, int id)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      if (!_ctx.Images.Any(c => c.Id == id))
        throw new EntityNotFoundException($"Image :{id}: not found!");

      if (!_ctx.Products.Include(p => p.Images).Any(a => a.Id == productId && a.Images.Any(i => i.Id == id)))
        throw new InconsistentStructureException($"Product :{productId}: doesn't contain Image :{id}:");

      var model = _ctx.Images.Find(id);

      _ctx.Images.Remove(model);

      return true;
    }

    public IImage Get(int id)
    {
      if (!_ctx.Images.Any(c => c.Id == id))
        throw new EntityNotFoundException($"Image :{id}: not found!");

      var result = _ctx.Images.Include(i => i.Full)
        .Include(i => i.Thumb)
        .First(i => i.Id == id);

      return result;
    }

    public IEnumerable<IImage> GetAll(int productId)
    {
      if (!_ctx.Products.Any(c => c.Id == productId))
        throw new EntityNotFoundException($"Product :{productId}: not found!");

      var result = _ctx.Products
        .Include(p => p.Images)
        .First(a => a.Id == productId)
        .Images;

      foreach (var img in result)
      {
        img.Full = _ctx.Files.Find(img.FullId);
      }

      return result;
    }

    public IImage Update(int productId, int id, IPutImage image)
    {
      var entity = _ctx.Images.Find(id);
      if (entity == null) return null;

      if (!_ctx.Products.Any(p => p.Id == productId) || !_ctx.Products.Include(p => p.Images).Any(p => p.Images.Any(i => i.Id == id)))
        throw new InconsistentStructureException($"Image :{id}: is not in Product :{productId}:");

      entity = _mapper.Map(image, entity);
      _ctx.Images.Update(entity);
      _ctx.SaveChanges();

      return entity;
    }
  }
}
