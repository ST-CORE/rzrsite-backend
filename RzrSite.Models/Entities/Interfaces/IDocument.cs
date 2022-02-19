namespace RzrSite.Models.Entities.Interfaces
{
  public interface IDocument
  {
    int Id { get; set; }
    string Description { get; set; }
    public int Weight { get; set; }
    public int FileId { get; set; }
    IDbFile File { get; set; }
  }
}