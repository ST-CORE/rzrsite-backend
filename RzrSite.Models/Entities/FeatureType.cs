using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class FeatureType : IFeatureType
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
