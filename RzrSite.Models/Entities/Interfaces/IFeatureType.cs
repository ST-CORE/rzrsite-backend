namespace RzrSite.Models.Entities.Interfaces
{
  public interface IFeatureType
  {
    int Id { get; set; }
    public int CategoryId { get; set; }
    string Name { get; set; }
    public string Units { get; set; }
  }
}