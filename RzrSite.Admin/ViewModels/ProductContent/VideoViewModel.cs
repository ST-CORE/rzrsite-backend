using RzrSite.Models.Responses.Video;

namespace RzrSite.Admin.ViewModels.ProductContent
{
  public class VideoViewModel
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public int CategoryId { get; set; }
		public int ProductLineId { get; set; }
		public int ProductId { get; set; }


		public VideoViewModel(FullVideo video, int categoryId, int productLineId, int productId)
		{
			Id = video.Id;
			Description = video.Description;
			Url = video.Url;
			CategoryId = categoryId;
			ProductLineId = productLineId;
			ProductId = productId;
		}
	}
}
