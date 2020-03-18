using RzrSite.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Category : ICategory
  {
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string UrlPart { get; set; }
  }
}
