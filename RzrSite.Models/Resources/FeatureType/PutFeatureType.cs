using RzrSite.Models.Resources.FeatureType.Interface;

namespace RzrSite.Models.Resources.FeatureType
{
  public class PutFeatureType: IPutFeatureType
  {
    public string Name { get; set; }
    public string Units { get; set; }
  }
}
