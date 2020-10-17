using System.Collections.Generic;

namespace RzrSite.Models.Resources.FeatureGroup
{
  public class FeatureGroup
  {
    public int ProductLineId { get; set; }
    public List<FeatureList> FeatureGroups { get; set; }
  }
}
