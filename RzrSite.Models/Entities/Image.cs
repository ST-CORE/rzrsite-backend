using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Image : IImage
  {
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    [ForeignKey("Full")]
    public int FullId { get; set; }
    [ForeignKey("Thumb")]
    public int ThumbId { get; set; }
    public IDbFile Full { get; set; }
    public IDbFile Thumb { get; set; }
  }
}
