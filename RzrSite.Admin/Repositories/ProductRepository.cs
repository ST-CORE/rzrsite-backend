using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Product;
using RzrSite.Models.Responses.Product;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories
{
  public class ProductRepository : IProductRepository
  {
    HttpClient _client = new HttpClient(); 
    public async Task<bool?> AddProduct(int categoryId, int productLineId, PostProduct model)
    {
      var stringifiedObject = JsonConvert.SerializeObject(model);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/product", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return null;
    }

    public async Task<Product> GetProduct(int categoryId, int productLineId, int id)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/product/{id}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Product>(resultString);
      }

      return null;
    }

    public async Task<IList<Product>> GetProducts(int categoryId, int productLineId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/product");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<Product>>(resultString);
      }

      return null;
    }

    public async Task<bool> RemoveProduct(int categoryId, int productLineId, int id)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/product/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<Product> UpdateProduct(int categoryId, int productLineId, int id, PutProduct product)
    {
      var stringifiedObject = JsonConvert.SerializeObject(product);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/product/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Product>(resultString);
      }

      return null;
    }
  }
}
