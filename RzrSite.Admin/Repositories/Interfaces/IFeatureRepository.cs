using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Feature;
using RzrSite.Models.Responses.Feature;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface IFeatureRepository
  {
    Task<AddedFeature> AddFeature(int productId, PostFeature postFeature);
    Task<IList<Feature>> GetFeatures(int productId);
    Task<Feature> GetFeature(int productId, int id);
    Task<Feature> UpdateProduct(int productId, int id, PutFeature putFeature);
    Task<bool> RemoveProduct(int productId, int id);
  }
}
