using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Product : IProduct
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public string Path { get; set; }
    public int Weight { get; set; }
    [ForeignKey("ProductLine")]
    public int ProductLineId { get; set; }
    [ForeignKey("PrimaryImage")]
    public int? PrimaryImageId { get; set; }
    public IImage PrimaryImage { get; set; }
    public IList<IImage> Images { get; set; }
    public IList<IFeature> Features { get; set; }
  }
}
