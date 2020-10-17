using RzrSite.Models.Resources.Image.Interface;

namespace RzrSite.Models.Resources.Image
{
  public class PutImage : IPutImage
  {
    public string Title { get; set; }
    public int Weight { get; set; }
    public int? FullId { get; set; }
    public int? ThumbId { get; set; }
  }
}
