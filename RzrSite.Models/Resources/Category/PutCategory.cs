using RzrSite.Models.Resources.Category.Interfaces;
using RzrSite.Models.ValidationAttributes;

namespace RzrSite.Models.Resources.Category
{
  public class PutCategory: IPutCategory
  {
    public string Name { get; set; }
    public int Weight { get; set; }
    [UrlSafe]
    public string Path { get; set; }
  }
}
