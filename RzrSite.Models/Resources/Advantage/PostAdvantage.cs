using RzrSite.Models.Resources.Advantage.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Resources.Advantage
{
  public class PostAdvantage : IPostAdvantage
  {
    [Required]
    public string Title { get; set; }
    [Required]
    public int Weight { get; set; }
  }
}
