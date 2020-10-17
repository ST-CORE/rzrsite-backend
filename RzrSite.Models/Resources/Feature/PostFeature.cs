using RzrSite.Models.Resources.Feature.Interfaces;

namespace RzrSite.Models.Resources.Feature
{
  public class PostFeature : IPostFeature
  {
    public int Weight { get; set; }
    public string Value { get; set; }
    public int FeatureTypeId { get; set; }
  }
}
