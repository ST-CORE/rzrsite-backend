using RzrSite.Models.Resources.Product.Interface;

namespace RzrSite.Models.Resources.Product
{
  public class PostProduct : IPostProduct
  {
    public string Name { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public string Path { get; set; }
    public int Weight { get; set; }
  }
}
