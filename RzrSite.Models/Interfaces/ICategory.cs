using System;

namespace RzrSite.Models.Interfaces
{
  /// <summary>
  /// Category of a product
  /// </summary>
  public interface ICategory
  {
    int Id { get; set; }
    string Title { get; set; }
    string UrlPart { get; set; }
  }
}
