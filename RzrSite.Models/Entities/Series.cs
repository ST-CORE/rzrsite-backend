using RzrSite.Models.Aggregations;
using RzrSite.Models.Aggregations.Interfaces;
using RzrSite.Models.Comparers;
using RzrSite.Models.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Series : ISeries
  {
    [Key]
    public int Id { get; set; }
    public string Path { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    [NotMapped] //TODO: Remove
    public IList<IAdvantage> Advantages { get; set; }
    [NotMapped] //TODO: Remove
    public IList<IDocument> Documents { get; set; }
    [NotMapped] //TODO: Remove
    public IList<IProduct> Products { get; set; }
  }
}
