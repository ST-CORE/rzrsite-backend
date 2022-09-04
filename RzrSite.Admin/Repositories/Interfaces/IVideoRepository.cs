using RzrSite.Models.Resources.Video;
using RzrSite.Models.Responses.Video;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface IVideoRepository
  {
    Task<IList<FullVideo>> GetVideos(int productId);
    Task<FullVideo> GetVideo(int productId, int id);
    Task<bool> RemoveVideo(int productId, int id);
    Task<AddedVideo> AddVideo(int productId, PostVideo postVideo);
    Task<FullVideo> UpdateVideo(int productId, int id, PutVideo putVideo);
  }
}
