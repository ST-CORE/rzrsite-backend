using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.DbFile.Interfaces;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IDbFileRepo
  {
    IEnumerable<IStrippedDbFile> GetAll();
    IStrippedDbFile Get(int id);
    IStrippedDbFile Get(string path);
    IDbFile GetFull(int id);
    IDbFile GetFull(string path);
    int? Add(IPostDbFile file);
    IStrippedDbFile Update(int id, IPutDbFile file);
    bool Delete(int id);
  }
}
