using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Category : ICategory
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public string Path { get; set; }
    public IList<ISeries> Series { get; set; }
  }
}
