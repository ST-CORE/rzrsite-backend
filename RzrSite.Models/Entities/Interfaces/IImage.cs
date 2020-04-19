namespace RzrSite.Models.Entities.Interfaces
{
  public interface IImage
  {
    int Id { get; set; }
    string Description { get; set; }
    IDbFile Full { get; set; }
    IDbFile Thumb { get; set; }
    int Weight { get; set; }
  }
}