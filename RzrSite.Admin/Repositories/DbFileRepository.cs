using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Models.DbFile;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.DbFile.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repository
{
  public class DbFileRepository : IDbFileRepository
  {
    private readonly HttpClient _client = new HttpClient();

    public async Task<DbFileResponse> AddFile(IPostDbFile postFile)
    {
      throw new System.NotImplementedException();
    }

    public async Task<IList<IDbFile>> GetFileList()
    {
      var response = await _client.GetAsync(UrlLocator.ApiUrl);
      if (response.IsSuccessStatusCode)
      {
        var resultString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<IDbFile>>(resultString);
      }

      return null;
    }

    public async Task<DbFileResponse> RemoveFile(int id)
    {
      throw new System.NotImplementedException();
    }

    public async Task<DbFileResponse> UpdateFile(IPutDbFile putFile)
    {
      throw new System.NotImplementedException();
    }
  }
}
