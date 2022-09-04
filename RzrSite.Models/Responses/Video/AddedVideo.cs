namespace RzrSite.Models.Responses.Video
{
	public class AddedVideo
	{
		public string Path { get; set; }

		public AddedVideo(int productId, int id)
		{
			Path = $"api/Product/{productId}/Video/{id}";
		}
	}
}
