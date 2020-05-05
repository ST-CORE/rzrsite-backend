using RzrSite.Admin.Models.DbFile;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.DbFile.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repository
{
  public interface IDbFileRepository
  {
    Task<IList<IDbFile>> GetFileList();
    Task<DbFileResponse> RemoveFile(int id);
    Task<DbFileResponse> AddFile(IPostDbFile postFile);
    Task<DbFileResponse> UpdateFile(IPutDbFile putFile);
  }
}
