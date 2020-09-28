using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class FeatureType : IFeatureType
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Units { get; set; }
  }
}
