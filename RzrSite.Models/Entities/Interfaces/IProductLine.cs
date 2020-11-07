using System.Collections.Generic;

namespace RzrSite.Models.Entities.Interfaces
{
  /// <summary>
  /// Series of a product.
  /// </summary>
  public interface IProductLine
  {
    /// <summary>
    /// Automatically generated Id
    /// </summary>
    int Id { get; set; }
    /// <summary>
    /// Id of parent Category
    /// </summary>
    int CategoryId { get; set; }
    /// <summary>
    /// Url-Part of the Path
    /// </summary>
    string Path { get; set; }
    /// <summary>
    /// Displayed name
    /// </summary>
    string Name { get; set; }
    /// <summary>
    /// Displayed additional information
    /// </summary>
    string Description { get; set; }
    /// <summary>
    /// Sort parameter
    /// </summary>
    int Weight { get; set; }
    
    IList<IAdvantage> Advantages { get; set; }
    IList<IDocument> Documents { get; set; }
    IList<IProduct> Products { get; set; }

    bool IsShowOnMain { get; set; }
  }
}