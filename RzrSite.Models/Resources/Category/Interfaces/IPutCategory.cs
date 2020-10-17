using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Resources.Category.Interfaces
{
  public interface IPutCategory
  {
    string Name { get; set; }
    int Weight { get; set; }
    string Path { get; set; }
  }
}
