using AutoMapper;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Category.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class CategoryRepo: ICategoryRepo
  {
    private readonly RzrSiteDbContext _ctx;
    private readonly IMapper _mapper;

    public CategoryRepo(RzrSiteDbContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public IEnumerable<ICategory> GetAll()
    {
      return _ctx.Categories.ToList();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public ICategory Get(int id)
    {
      var category = _ctx.Categories.Find(id);
      category.ProductLines = _ctx.ProductLines.Any(pl => pl.CategoryId == id)? _ctx.ProductLines.Where(pl => pl.CategoryId == id).AsEnumerable<IProductLine>().ToList(): null;
      return category;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public ICategory Update(int id, IPutCategory category)
    {
      var entity = _ctx.Categories.Find(id);
      if (entity == null) return null;
      entity = _mapper.Map(category, entity);
      _ctx.Categories.Update(entity);
      _ctx.SaveChanges();
      return entity;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public int? Add(IPostCategory category)
    {
      var model = _mapper.Map<Category>(category);
      var result = _ctx.Categories.Add(model);
      _ctx.SaveChanges();
      return result.Entity?.Id;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool Delete(int id)
    {
      if (!_ctx.Categories.Any(c => c.Id.Equals(id))) return true;
      var category = _ctx.Categories.Find(id);
      if(category.ProductLines != null && category.ProductLines.Any()) return false;

      _ctx.Categories.Remove(category);

      _ctx.SaveChanges();
      return true;
    }
  }
}
