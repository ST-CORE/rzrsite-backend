namespace RzrSite.Models.Resources.Feature.Interfaces
{
  public interface IPostFeature
  {
    int Weight { get; set; }
    string Value { get; set; }
    int FeatureTypeId { get; set; }
  }
}
