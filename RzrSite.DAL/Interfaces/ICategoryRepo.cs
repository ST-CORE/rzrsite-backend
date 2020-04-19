using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace RzrSite.DAL.Interfaces
{
  public interface ICategoryRepo
  {
    /// <summary>
    /// Retrieves all categories from DB
    /// </summary>
    /// <returns>List of <see cref="ICategory"/></returns>
    IEnumerable<ICategory> GetCategories();
  }
}
