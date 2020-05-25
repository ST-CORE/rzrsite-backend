using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class ProductLine : IProductLine
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public string Path { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public IList<IAdvantage> Advantages { get; set; }
    public IList<IDocument> Documents { get; set; }
    public IList<IProduct> Products { get; set; }
  }
}
