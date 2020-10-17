using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Advantage : IAdvantage
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("ProductLine")]
    public int ProductLineId { get; set; }
    public string Title { get; set; }
    public int Weight { get; set; }
    [ForeignKey("Icon")]
    public int? IconId { get; set; }
    public IDbFile Icon { get; set; }
  }
}
