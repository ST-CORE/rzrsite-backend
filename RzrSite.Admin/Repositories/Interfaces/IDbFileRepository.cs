using Microsoft.AspNetCore.Http;
using RzrSite.Admin.Models.DbFile;
using RzrSite.Models.Resources.DbFile;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repository
{
  public interface IDbFileRepository
  {
    Task<IList<StrippedDbFile>> GetFileList();
    Task<DbFileResponse> RemoveFile(int id);
    Task<DbFileResponse> AddFile(PostDbFile postFile);
    Task<DbFileResponse> UpdateFile(PutDbFile putFile);
  }
}
