using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Category.Interfaces;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface ICategoryRepo
  {
    /// <summary>
    /// Retrieves all existing categories
    /// </summary>
    /// <returns>List of <see cref="ICategory"/></returns>
    IEnumerable<ICategory> GetAll();
    /// <summary>
    /// Retrieves category by Id
    /// </summary>
    /// <param name="id">Id of category</param>
    /// <returns>Category</returns>
    ICategory Get(int id);
    /// <summary>
    /// Adds new category by POST resource representation
    /// </summary>
    /// <param name="category">POST resource representation</param>
    /// <returns>Id of added category</returns>
    int? Add(IPostCategory category);
    /// <summary>
    /// Updates existing category by PUT resource representation
    /// </summary>
    /// <param name="id">Id of category to be updated</param>
    /// <param name="category">PUT resource representation</param>
    /// <returns>Updated category; Null - if not found</returns>
    ICategory Update(int id, IPutCategory category);
    /// <summary>
    /// Removes empty category by Id
    /// </summary>
    /// <param name="id">Id of category to remove</param>
    /// <returns>True if category was removed or not found; False - if not empty;</returns>
    bool Delete(int id);
  }
}
