using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace RzrSite.Models.Resources.FeatureGroup
{
  public class FeatureList
  {
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public List<IFeature> Features { get; set; }
  }
}
