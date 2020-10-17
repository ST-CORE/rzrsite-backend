using RzrSite.Models.Resources.Advantage.Interfaces;

namespace RzrSite.Models.Resources.Advantage
{
  public class PutAdvantage : IPutAdvantage
  {
    public string Title { get; set; }
    public int Weight { get; set; }
    public int? IconId { get; set; }
  }
}
