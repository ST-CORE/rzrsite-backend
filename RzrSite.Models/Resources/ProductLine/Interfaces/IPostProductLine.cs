namespace RzrSite.Models.Resources.ProductLine.Interfaces
{
  public interface IPostProductLine
  {
    string Path { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Weight { get; set; }
  }
}
