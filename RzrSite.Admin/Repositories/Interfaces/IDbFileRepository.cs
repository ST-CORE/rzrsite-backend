﻿using RzrSite.Admin.Models.DbFile;
using RzrSite.Models.Resources.DbFile;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repository
{
  public interface IDbFileRepository
  {
    Task<IList<StrippedDbFile>> GetFileList();
    Task<StrippedDbFile> GetFile(int id);
    Task<byte[]> GetFileContent(int id);
    Task<bool> RemoveFile(int id);
    Task<DbFileResponse> AddFile(PostDbFile postFile);
    Task<StrippedDbFile> UpdateFile(int id, PutDbFile putFile);
  }
}
