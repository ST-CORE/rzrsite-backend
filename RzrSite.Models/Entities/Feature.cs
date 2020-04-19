using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Feature : IFeature
  {
    [Key]
    public int Id { get; set; }
    public int Weight { get; set; }
    public int ProductId { get; set; }
    public IFeatureType Type { get; set; }
    public string Value { get; set; }
  }
}
