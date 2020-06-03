using RzrSite.Models.Responses.Image;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.Images
{
  public class ListViewModel
  {
    public IList<FullImage> Images { get; set; }
    public int CategoryId { get; set; }
    public int ProductLineId { get; set; }
    public int ProductId { get; set; }

    public ListViewModel()
    {

    }

    public ListViewModel(IList<FullImage> images, int categoryId, int productLineId, int productId)
    {
      Images = images ?? new List<FullImage>();
      CategoryId = categoryId;
      ProductLineId = productLineId;
      ProductId = productId;
    }
  }
}
