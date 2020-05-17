using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;

namespace RzrSite.Models.Responses.Category
{
  public class FullCategory
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public string Path { get; set; }
    public IList<StrippedProductLine> ProductLines { get; set; }
  }
}
