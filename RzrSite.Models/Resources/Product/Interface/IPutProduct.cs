namespace RzrSite.Models.Resources.Product.Interface
{
  public interface IPutProduct
  {
    string Name { get; set; }
    string Title { get; set; }
    decimal Price { get; set; }
    bool InStock { get; set; }
    int Weight { get; set; }
    string Path { get; set; }
  }
}
