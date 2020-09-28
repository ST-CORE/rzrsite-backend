using RzrSite.Models.Entities;
using RzrSite.Models.Resources.FeatureType;
using RzrSite.Models.Responses.FeatureType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface IFeatureTypeRepository
  {
    Task<IList<FeatureType>> GetAllFeatureTypes(int categoryId);
    Task<FeatureType> GetFeatureType(int categoryId, int id);
    Task<AddedFeatureType> AddFeatureType(int categoryId, PostFeatureType postModel);
    Task<FeatureType> UpdateFeatureType(int categoryId, int id, PutFeatureType putModel);
    Task<bool> RemoveFeatureType(int categoryId, int id);
  }
}
