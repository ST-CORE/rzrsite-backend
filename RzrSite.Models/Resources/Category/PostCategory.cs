using RzrSite.Models.Resources.Category.Interfaces;
using RzrSite.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Resources.Category
{
  public class PostCategory : IPostCategory
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public int Weight { get; set; }
    [Required, UrlSafe]
    public string Path { get; set; }
  }
}
