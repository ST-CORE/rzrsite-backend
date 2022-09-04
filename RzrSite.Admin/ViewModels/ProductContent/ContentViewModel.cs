using RzrSite.Models.Responses.Image;
using RzrSite.Models.Responses.Video;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.Admin.ViewModels.ProductContent
{
  public class ContentViewModel
  {
    public ImageViewModel Image { get; set; }
    public VideoViewModel Video { get; set; }
    public int Weight { get; set; }

    public static IList<ContentViewModel> Group(IList<FullImage> images, IList<FullVideo> videos, int categoryId, int productLineId, int productId)
    {
      var result = new List<ContentViewModel>();

      if (images?.Any() ?? false)
      {
        result.AddRange(images.Select(i => new ContentViewModel
        {
          Image = new ImageViewModel(i, categoryId, productLineId, productId),
          Weight = i.Weight
        }));
      }

      if (videos?.Any() ?? false)
      {
        result.AddRange(videos.Select(v => new ContentViewModel
        {
          Video = new VideoViewModel(v, categoryId, productLineId, productId),
          Weight = v.Weight
        }));
      }

			return result.OrderBy(c => c.Weight).ToList();
    }
  }
}
