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
    public int Weight { get; set; }
    [NotMapped]
    public IImage PrimaryImage { get; set; }
    [NotMapped]
    public IList<IImage> Images { get; set; }
    [NotMapped]
    public IList<IFeature> Features { get; set; }
  }
}
