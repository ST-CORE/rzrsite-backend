namespace RzrSite.Models.Resources.Video.Interface
{
	public interface IPostVideo
	{
		public string Description { get; set; }
		public string Url { get; set; }
		public int Weight { get; set; }
	}
}
