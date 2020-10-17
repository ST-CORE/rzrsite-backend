namespace RzrSite.Models.Resources.Feature.Interfaces
{
  public interface IPutFeature
  {
    int Weight { get; set; }
    string Value { get; set; }
    int FeatureTypeId { get; set; }
  }
}
