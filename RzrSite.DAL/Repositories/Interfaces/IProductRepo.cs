using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Product.Interface;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IProductRepo
  {
    /// <summary>
    /// Retrieves products
    /// </summary>
    /// <param name="productLineId">Id of parent product line</param>
    /// <returns>List of <see cref="IProduct"/> for one <see cref="IProductLine"/> </returns>
    IEnumerable<IProduct> GetAll(int productLineId);
    /// <summary>
    /// Retrieves single product
    /// </summary>
    /// <param name="id">Id of Product</param>
    /// <returns><see cref="IProduct"/>; Null if not found;</returns>
    IProduct Get(int id);
    /// <summary>
    /// Retrieves single product
    /// </summary>
    /// <param name="productLineId">Id of product line to get from</param>
    /// <param name="id">Id of Product</param>
    /// <returns><see cref="IProduct"/>; Null if not found;</returns>
    IProduct Get(int productLineId, int id);
    /// <summary>
    /// Adds new product by POST resource representation
    /// </summary>
    /// <param name="productLineId">Id of category to add to</param>
    /// <param name="product">POST resource representation</param>
    /// <returns>Id of added product</returns>
    int? Add(int productLineId, IPostProduct product);
    /// <summary>
    /// Updates existing product by PUT resource representation
    /// </summary>
    /// <param name="productLineId">Id of parent productLine</param>
    /// <param name="id">Id of product to be updated</param>
    /// <param name="product">PUT resource representation</param>
    /// <returns>Updated product; Null - if not found</returns>
    IProduct Update(int productLineId, int id, IPutProduct product);
    /// <summary>
    /// Removes product by Id (recursive)
    /// </summary>
    /// <param name="productLineId">Id of parent productLine</param>
    /// <param name="id">Id of product to remove</param>
    /// <returns>True if product was removed or not found; False - if not empty;</returns>
    bool Delete(int productLineId, int id);
  }
}
