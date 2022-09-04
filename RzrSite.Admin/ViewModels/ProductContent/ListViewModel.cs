using RzrSite.Models.Responses.Image;
using RzrSite.Models.Responses.Video;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.ProductContent
{
  public class ListViewModel
  {
		public int CategoryId { get; set; }
    public int ProductLineId { get; set; }
    public int ProductId { get; set; }
    public IList<ContentViewModel> Content { get; set; }

    public ListViewModel()
    {

    }

    public ListViewModel(IList<FullImage> images, IList<FullVideo> videos, int categoryId, int productLineId, int productId)
    {
      Content = ContentViewModel.Group(images, videos, categoryId, productLineId, productId);
			CategoryId = categoryId;
      ProductLineId = productLineId;
      ProductId = productId;
    }
  }
}
