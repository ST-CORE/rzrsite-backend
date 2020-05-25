using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.Advantage;
using RzrSite.Models.Responses.Advantage;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace RzrSite.Admin.Repositories
{
  public class AdvantageRepository : IAdvantageRepository
  {
    private readonly HttpClient _client = new HttpClient();

    public async Task<AddedAdvantage> AddAdvantage(int productLineId, PostAdvantage advantage)
    {
      var stringifiedObject = JsonConvert.SerializeObject(advantage);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/ProductLine/{productLineId}/advantage", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AddedAdvantage>(resultString);
      }

      return null;
    }

    public async Task<FullAdvantage> GetAdvantage(int productLineId, int id)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/ProductLine/{productLineId}/advantage/{id}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullAdvantage>(resultString);
      }

      return null;
    }

    public async Task<IList<FullAdvantage>> GetAdvantages(int productLineId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/ProductLine/{productLineId}/advantage/");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<FullAdvantage>>(resultString);
      }

      return null;
    }

    public async Task<bool> RemoveAdvantage(int productLineId, int id)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/ProductLine/{productLineId}/advantage/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<FullAdvantage> UpdateAdvantage(int productLineId, int id, PutAdvantage advantage)
    {
      var stringifiedObject = JsonConvert.SerializeObject(advantage);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/ProductLine/{productLineId}/advantage/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullAdvantage>(resultString);
      }

      return null;
    }
  }
}
