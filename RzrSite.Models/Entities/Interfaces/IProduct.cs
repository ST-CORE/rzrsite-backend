using System.Collections.Generic;

namespace RzrSite.Models.Entities.Interfaces
{
  public interface IProduct
  {
    int Id { get; set; }
    string Name { get; set; }
    string Title { get; set; }
    decimal Price { get; set; }
    bool InStock { get; set; }
    int Weight { get; set; }

    IImage PrimaryImage { get; set; }
    IList<IImage> Images { get; set; }

    IList<IFeature> Features { get; set; }
  }
}