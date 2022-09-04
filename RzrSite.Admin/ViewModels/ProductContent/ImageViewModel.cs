using RzrSite.Models.Responses.Image;

namespace RzrSite.Admin.ViewModels.ProductContent
{
  public class ImageViewModel
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string FullPath { get; set; }
		public string ThumbPath { get; set; }
		public int CategoryId { get; set; }
		public int ProductLineId { get; set; }
		public int ProductId { get; set; }


		public ImageViewModel(FullImage image, int categoryId, int productLineId, int productId)
		{
			Id = image.Id;
			Description = image.Description;
			FullPath = image.FullPath;
			ThumbPath = image.ThumbPath;
			CategoryId = categoryId;
			ProductLineId = productLineId;
			ProductId = productId;
		}
	}
}
