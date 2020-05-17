using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.Category;
using RzrSite.Models.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly HttpClient _client = new HttpClient();

    public async Task<AddedCategory> AddCategory(PostCategory postCategory)
    {
      var stringifiedObject = JsonConvert.SerializeObject(postCategory);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/category", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AddedCategory>(resultString);
      }

      return null;
    }

    public async Task<IList<StrippedCategory>> GetCategories()
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<StrippedCategory>>(resultString);
      }

      return null;
    }

    public async Task<FullCategory> GetCategory(int categoryId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullCategory>(resultString);
      }

      return null;
    }

    public async Task<bool> RemoveCategory(int categoryId)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/category/{categoryId}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<StrippedCategory> UpdateCategory(int categoryId, PutCategory putCategory)
    {
      var stringifiedObject = JsonConvert.SerializeObject(putCategory);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/category/{categoryId}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<StrippedCategory>(resultString);
      }

      return null;
    }
  }
}
