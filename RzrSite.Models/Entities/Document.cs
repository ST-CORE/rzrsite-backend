using RzrSite.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [NotMapped]
    public IDbFile File { get; set; }
  }
}
