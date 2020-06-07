using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.FeatureType.Interface;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IFeatureTypeRepo
  {
    /// <summary>
    /// Retrieves all existing feature types
    /// </summary>
    /// <returns>List of <see cref="IFeatureType"/></returns>
    IEnumerable<IFeatureType> GetAll();
    /// <summary>
    /// Retrieves feature type by Id
    /// </summary>
    /// <param name="id">Id of feature type</param>
    /// <returns>Category</returns>
    IFeatureType Get(int id);
    /// <summary>
    /// Adds new featuret type by POST resource representation
    /// </summary>
    /// <param name="featureType">POST resource representation</param>
    /// <returns>Id of added feature type</returns>
    int? Add(IPostFeatureType featureType);
    /// <summary>
    /// Updates existing feature type by PUT resource representation
    /// </summary>
    /// <param name="id">Id of feature type to be updated</param>
    /// <param name="featureType">PUT resource representation</param>
    /// <returns>Updated feature type; Null - if not found</returns>
    IFeatureType Update(int id, IPutFeatureType featureType);
    /// <summary>
    /// Removes feature type by Id
    /// </summary>
    /// <param name="id">Id of feature type to remove</param>
    /// <returns>True if feature type was removed or not found; False - if not empty;</returns>
    bool Delete(int id);
  }
}
