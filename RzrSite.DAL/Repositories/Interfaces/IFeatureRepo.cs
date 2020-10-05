using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Feature.Interfaces;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IFeatureRepo
  {
    /// <summary>
    /// Retrieves all features for a product
    /// </summary>
    /// <param name="productId">Id of a product</param>
    /// <returns>List of <see cref="IFeature"/></returns>
    IEnumerable<IFeature> GetAll(int productId);
    /// <summary>
    /// Retrieves feature by Id
    /// </summary>
    /// <param name="productId">Id of a product</param>
    /// <param name="id">Id of feature</param>
    /// <returns>Category</returns>
    IFeature Get(int productId, int id);

    IFeature Get(int productId, int id, int featureTypeId);

    /// <summary>
    /// Adds new feature by POST resource representation
    /// </summary>
    /// <param name="productId">Id of a product</param>
    /// <param name="feature">POST resource representation</param>
    /// <returns>Id of added feature type</returns>
        int? Add(int productId, IPostFeature feature);
    /// <summary>
    /// Updates existing feature type by PUT resource representation
    /// </summary>
    /// <param name="productId">Id of a product</param>
    /// <param name="id">Id of feature type to be updated</param>
    /// <param name="featureType">PUT resource representation</param>
    /// <returns>Updated feature type; Null - if not found</returns>
    IFeature Update(int productId, int id, IPutFeature feature);
    /// <summary>
    /// Removes feature type by Id
    /// </summary>
    /// <param name="productId">Id of a product</param>
    /// <param name="id">Id of feature type to remove</param>
    /// <returns>True if feature type was removed or not found; False - if not empty;</returns>
    bool Delete(int productId, int id);
  }
}
