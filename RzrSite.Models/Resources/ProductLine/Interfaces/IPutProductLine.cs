namespace RzrSite.Models.Resources.ProductLine.Interfaces
{
  public interface IPutProductLine
  {
    string Path { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Weight { get; set; }
    bool IsShowOnMain { get; set; }
  }
}
