using RzrSite.Models.Resources.Advantage;
using RzrSite.Models.Responses.Advantage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface IAdvantageRepository
  {
    Task<FullAdvantage> GetAdvantage(int productLineId, int id);
    Task<IList<FullAdvantage>> GetAdvantages(int productLineId);
    Task<bool> RemoveAdvantage(int productLineId, int id);
    Task<AddedAdvantage> AddAdvantage(int productLineId, PostAdvantage advantage);
    Task<FullAdvantage> UpdateAdvantage(int productLineId, int id, PutAdvantage advantage);
  }
}
