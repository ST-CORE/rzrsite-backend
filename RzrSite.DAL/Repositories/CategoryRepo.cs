using RzrSite.DAL.Interfaces;
using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
  public class CategoryRepo: ICategoryRepo
  {
    private readonly RzrSiteDbContext _ctx;

    public CategoryRepo(RzrSiteDbContext ctx)
    {
      _ctx = ctx;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public IEnumerable<ICategory> GetCategories()
    {
      return _ctx.Categories.ToList();
    }
  }
}
