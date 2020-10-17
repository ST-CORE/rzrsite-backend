using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Models.Resources.DbFile;
using RzrSite.Models.Responses.DbFile;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repository
{
  public class DbFileRepository : IDbFileRepository
  {
    private readonly HttpClient _client = new HttpClient();

    public async Task<AddedDbFile> AddFile(PostDbFile file)
    {
      var stringifiedObject = JsonConvert.SerializeObject(file);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/dbfile", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AddedDbFile>(resultString);
      }

      return null;
    }

    public async Task<StrippedDbFile> GetFile(int id)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/dbfile/{id}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<StrippedDbFile>(resultString);
      }

      return null;
    }

    public async Task<byte[]> GetFileContent(int id)
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/dbfile/content/{id}");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<byte[]>(resultString);
      }

      return null;
    }

    public async Task<StrippedDbFile> GetStrippedFile(int id)
    {
        var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/dbfile/content/{id}");
        if (response.IsSuccessStatusCode)
        {
            var resultString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<StrippedDbFile>(resultString);
            return data;
        }
        return null;
    }

        public async Task<IList<StrippedDbFile>> GetFileList()
    {
      var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/dbfile");
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<StrippedDbFile>>(resultString);
      }

      return null;
    }

    public async Task<bool> RemoveFile(int id)
    {
      var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/dbfile/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }

      return false;
    }

    public async Task<StrippedDbFile> UpdateFile(int id, PutDbFile putFile)
    {
      var stringifiedObject = JsonConvert.SerializeObject(putFile);
      var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/dbfile/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<StrippedDbFile>(resultString);
      }

      return null;
    }
  }
}
