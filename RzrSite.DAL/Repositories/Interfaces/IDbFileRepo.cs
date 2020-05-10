using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.DbFile.Interfaces;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IDbFileRepo
  {
    IEnumerable<IStrippedDbFile> GetAll();
    IStrippedDbFile Get(int id);
    IDbFile Get(string path);
    int? Add(IPostDbFile file);
    IStrippedDbFile Update(int id, IPutDbFile file);
    bool Delete(int id);
  }
}
