using AutoMapper;
using RzrSite.DAL.Reposiories.Interfaces;
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
    public IEnumerable<ICategory> GetCategories()
    {
      return _ctx.Categories.ToList();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public ICategory GetCategory(int id)
    {
      return _ctx.Categories.Find(id);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public ICategory UpdateCategory(int id, IPutCategory category)
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
    public int? AddCategory(IPostCategory category)
    {
      var model = _mapper.Map<Category>(category);
      var result = _ctx.Categories.Add(model);
      _ctx.SaveChanges();
      return result.Entity?.Id;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public bool DeleteCategory(int id)
    {
      if (!_ctx.Categories.Any(c => c.Id.Equals(id))) return true;
      var category = _ctx.Categories.Find(id);
      if(category.Series != null && category.Series.Any()) return false;

      _ctx.Categories.Remove(category);

      _ctx.SaveChanges();
      return true;
    }
  }
}
