using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Models.DbFile;
using RzrSite.Models.Resources.DbFile;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repository
{
  public class DbFileRepository : IDbFileRepository
  {
    private readonly HttpClient _client = new HttpClient();

    public async Task<DbFileResponse> AddFile(PostDbFile file)
    {
      var stringifiedObject = JsonConvert.SerializeObject(file);
      var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/dbfile", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<DbFileResponse>(resultString);
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

    public async Task<DbFileResponse> RemoveFile(int id)
    {
      throw new System.NotImplementedException();
    }

    public async Task<DbFileResponse> UpdateFile(PutDbFile putFile)
    {
      throw new System.NotImplementedException();
    }
  }
}
