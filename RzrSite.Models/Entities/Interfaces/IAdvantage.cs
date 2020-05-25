namespace RzrSite.Models.Entities.Interfaces
{
  public interface IAdvantage
  {
    int Id { get; set; }
    int ProductLineId { get; set; }
    string Title { get; set; }
    int Weight { get; set; }
    int? IconId { get; set; }
    IDbFile Icon { get; set; }
  }
}