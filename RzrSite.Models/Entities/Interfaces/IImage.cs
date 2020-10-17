namespace RzrSite.Models.Entities.Interfaces
{
  public interface IImage
  {
    int Id { get; set; }
    string Description { get; set; }
    int? FullId { get; set; }
    IDbFile Full { get; set; }
    int? ThumbId { get; set; }
    IDbFile Thumb { get; set; }
    int Weight { get; set; }
  }
}