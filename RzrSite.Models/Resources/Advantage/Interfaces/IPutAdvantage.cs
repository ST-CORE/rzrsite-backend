namespace RzrSite.Models.Resources.Advantage.Interfaces
{
  public interface IPutAdvantage
  {
    public string Title { get; set; }
    public int Weight { get; set; }
    public int? IconId { get; set; } 
  }
}
