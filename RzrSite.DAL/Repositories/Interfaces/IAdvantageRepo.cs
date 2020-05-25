using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Advantage.Interfaces;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IAdvantageRepo
  {
    /// <summary>
    /// Retrieves advantages
    /// </summary>
    /// <param name="productLineId">Id of productLine</param>
    /// <returns>List of <see cref="IAdvantage"/> for one <see cref="IProductLine"/> </returns>
    IEnumerable<IAdvantage> GetAll(int productLineId);
    /// <summary>
    /// Retrieves single advantage
    /// </summary>
    /// <param name="id">Id of advantage</param>
    /// <returns><see cref="IAdvantage"/>; Null if not found;</returns>
    IAdvantage Get(int id);
    /// <summary>
    /// Adds new advantage by POST resource representation
    /// </summary>
    /// <param name="productLineId">Id of product line to add to</param>
    /// <param name="advantage">POST resource representation</param>
    /// <returns>Id of added advantage</returns>
    int? Add(int productLineId, IPostAdvantage advantage);
    /// <summary>
    /// Updates existing product line by PUT resource representation
    /// </summary>
    /// <param name="productLineId">Id of parent product line</param>
    /// <param name="id">Id of advantage to be updated</param>
    /// <param name="advantage">PUT resource representation</param>
    /// <returns>Updated product line; Null - if not found</returns>
    IAdvantage Update(int productLineId, int id, IPutAdvantage advantage);
    /// <summary>
    /// Removes product line without products by Id
    /// </summary>
    /// <param name="categoryId">Id of parent category</param>
    /// <param name="id">Id of product line to remove</param>
    /// <returns>True if prouct line was removed or not found; False - if not empty;</returns>
    bool Delete(int categoryId, int id);
  }
}
