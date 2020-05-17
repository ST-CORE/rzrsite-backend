using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace RzrSite.Models.Responses.ProductLine
{
  public class FullProductLine
  {
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Path { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public IList<IAdvantage> Advantages { get; set; }
    public IList<IDocument> Documents { get; set; }
    public IList<IProduct> Products { get; set; }
  }
}
