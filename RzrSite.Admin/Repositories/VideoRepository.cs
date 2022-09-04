using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Resources.Video;
using RzrSite.Models.Responses.Video;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories
{
  public class VideoRepository : IVideoRepository
  {
    HttpClient _client;

    public VideoRepository()
    {
      _client = new HttpClient();
    }

    public async Task<AddedVideo> AddVideo(int productId, PostVideo postVideo)
    {
      var stringifiedObject = JsonConvert.SerializeObject(postVideo);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Video/", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AddedVideo>(resultString);
      }

      return null;
    }

    public async Task<FullVideo> GetVideo(int productId, int id)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Video/{id}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullVideo>(resultString);
      }

      return null;
    }

    public async Task<FullVideo> GetPrimaryVideo(int productId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/PrimaryVideo");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullVideo>(resultString);
      }

      return null;
    }

    public async Task<IList<FullVideo>> GetVideos(int productId)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Video/");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<FullVideo>>(resultString);
      }

      return null;
    }

    public async Task<bool> RemoveVideo(int productId, int id)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Video/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<FullVideo> UpdateVideo(int productId, int id, PutVideo putVideo)
    {
      var stringifiedObject = JsonConvert.SerializeObject(putVideo);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/Product/{productId}/Video/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FullVideo>(resultString);
      }

      return null;
    }
  }
}
