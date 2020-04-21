using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Resources.Category.Interfaces
{
  public interface IPostCategory
  {
    string Name { get; set; }
    int Weight { get; set; }
    string Path { get; set; }
  }
}
