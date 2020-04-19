using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Document : IDocument
  {
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public IDbFile File { get; set; }
  }
}
