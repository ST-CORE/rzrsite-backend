using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.ProductLine;
using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories
{
  public class ProductLineRepository : IProductLineRepository
  {
    private readonly HttpClient _client = new HttpClient();

    public async Task<AddedProductLine> AddProductLine(int categoryId, PostProductLine postProductLine)
    {
      var stringifiedObject = JsonConvert.SerializeObject(postProductLine);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AddedProductLine>(resultString);
      }

      return null;
    }

    public async Task<FullProductLine> GetProductLine(int categoryId, int productLineId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullProductLine>(resultString);
      }

      return null;
    }

    public async Task<IList<StrippedProductLine>> GetProductLines(int categoryId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<StrippedProductLine>>(resultString);
      }

      return null;
    }

    public async Task<IList<ProductLineDocument>> GetProductLineDocuments(int categoryId, int productLineId)
    {
        var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/documents");
        if (response.IsSuccessStatusCode)
        {
            var resultString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IList<ProductLineDocument>>(resultString);
        }

        return null;
    }

        public async Task<bool> RemoveProductLine(int categoryId, int id)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<StrippedProductLine> UpdateProductLine(int categoryId, int id, PutProductLine putProductLine)
    {
      var stringifiedObject = JsonConvert.SerializeObject(putProductLine);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<StrippedProductLine>(resultString);
      }

      return null;
    }
  }
}
