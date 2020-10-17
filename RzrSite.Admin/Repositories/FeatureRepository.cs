using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Feature;
using RzrSite.Models.Responses.Feature;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories
{
  public class FeatureRepository: IFeatureRepository
  {

    readonly HttpClient _client;

    public FeatureRepository()
    {
      _client = new HttpClient();
    }

    public async Task<Feature> GetFeature(int productId, int id)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/feature/{id}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Feature>(resultString);
      }

      return null;
    }

    public async Task<IList<Feature>> GetFeatures(int productId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/feature");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<Feature>>(resultString);
      }

      return null;
    }

    public async Task<AddedFeature> AddFeature(int productId, PostFeature postModel)
    {
      var stringifiedObject = JsonConvert.SerializeObject(postModel);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Feature", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AddedFeature>(resultString);
      };

      return null;
    }


    public async Task<bool> RemoveProduct(int productId, int id)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Feature/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<Feature> UpdateProduct(int productId, int id, PutFeature putModel)
    {

      var stringifiedObject = JsonConvert.SerializeObject(putModel);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Feature/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Feature>(resultString);
      };

      return null;
    }
  }
}
