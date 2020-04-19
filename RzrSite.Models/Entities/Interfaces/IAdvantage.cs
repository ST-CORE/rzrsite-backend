namespace RzrSite.Models.Entities.Interfaces
{
  public interface IAdvantage
  {
    int Id { get; set; }
    string Title { get; set; }
    int Weight { get; set; }
    IDbFile Icon { get; set; }
  }
}