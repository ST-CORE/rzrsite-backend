using RzrSite.Models.Aggregations.Interfaces;
using System.Collections.Generic;

namespace RzrSite.Models.Entities.Interfaces
{
  public interface ISeries
  {
    int Id { get; set; }
    string Path { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Weight { get; set; }

    IList<IAdvantage> Advantages { get; set; }
    IList<IDocument> Documents { get; set; }
    IList<IProduct> Products { get; set; }
  }
}