using System.Collections.Generic;

namespace RzrSite.Models.Entities.Interfaces
{
  /// <summary>
  /// Category of a product
  /// </summary>
  public interface ICategory
  {
    int Id { get; set; }
    string Name { get; set; }
    int Weight { get; set; }
    string Path { get; set; }

    IList<ISeries> Series { get; set; }
  }
}
