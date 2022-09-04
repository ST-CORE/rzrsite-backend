using RzrSite.Models.Resources.Video.Interface;

namespace RzrSite.Models.Resources.Video
{
	public class PostVideo : IPostVideo
	{
		public string Description { get; set; }
		public string Url { get; set; }
		public int Weight { get; set; }
	}
}
