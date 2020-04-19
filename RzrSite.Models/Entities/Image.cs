using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

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
    public IDbFile Full { get; set; }
    public IDbFile Thumb { get; set; }
    public int Weight { get; set; }
  }
}
