using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public string Value { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    [ForeignKey("FeatureType")]
    public int TypeId { get; set; }
    [NotMapped]
    public IFeatureType Type { get; set; }
  }
}
