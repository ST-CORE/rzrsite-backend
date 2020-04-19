namespace RzrSite.Models.Entities.Interfaces
{
  public interface IFeature
  {
    int Id { get; set; }
    int Weight { get; set; }
    int ProductId { get; set; }

    IFeatureType Type { get; set; }
    string Value { get; set; }
  }
}