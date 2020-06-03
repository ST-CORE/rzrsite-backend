using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.Image;
using RzrSite.Models.Responses.Image;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories
{
  public class ImageRepository : IImageRepository
  {
    HttpClient _client;

    public ImageRepository()
    {
      _client = new HttpClient();
    }

    public async Task<AddedImage> AddImage(int productId, PostImage postImage)
    {
      var stringifiedObject = JsonConvert.SerializeObject(postImage);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Image/", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AddedImage>(resultString);
      }

      return null;
    }

    public async Task<FullImage> GetImage(int productId, int id)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Image/{id}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullImage>(resultString);
      }

      return null;
    }

    public async Task<FullImage> GetPrimaryImage(int productId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/PrimaryImage");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullImage>(resultString);
      }

      return null;
    }

    public async Task<IList<FullImage>> GetImages(int productId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Image/");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<FullImage>>(resultString);
      }

      return null;
    }

    public async Task<bool> RemoveImage(int productId, int id)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Image/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<FullImage> UpdateImage(int productId, int id, PutImage putImage)
    {
      var stringifiedObject = JsonConvert.SerializeObject(putImage);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Image/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullImage>(resultString);
      }

      return null;
    }
  }
}
