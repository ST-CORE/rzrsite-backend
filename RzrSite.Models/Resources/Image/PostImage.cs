using RzrSite.Models.Resources.Image.Interface;

namespace RzrSite.Models.Resources.Image
{
  public class PostImage : IPostImage
  {
    public string Description { get; set; }
    public int Weight { get; set; }
  }
}
