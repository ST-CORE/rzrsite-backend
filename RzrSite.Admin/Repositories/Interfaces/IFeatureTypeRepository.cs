using RzrSite.Models.Entities;
using RzrSite.Models.Resources.FeatureType;
using RzrSite.Models.Responses.FeatureType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface IFeatureTypeRepository
  {
    Task<IList<FeatureType>> GetAllFeatureTypes();
    Task<FeatureType> GetFeatureType(int id);
    Task<AddedFeatureType> AddFeatureType(PostFeatureType postModel);
    Task<FeatureType> UpdateFeatureType(int id, PutFeatureType putModel);
    Task<bool> RemoveFeatureType(int id);
  }
}
