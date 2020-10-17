using RzrSite.Models.Resources.Image;
using RzrSite.Models.Responses.Image;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface IImageRepository
  {
    Task<IList<FullImage>> GetImages(int productId);
    Task<FullImage> GetImage(int productId, int id);
    Task<FullImage> GetPrimaryImage(int productId);
    Task<bool> RemoveImage(int productId, int id);
    Task<AddedImage> AddImage(int productId, PostImage postImage);
    Task<FullImage> UpdateImage(int productId, int id, PutImage putImage);
  }
}
