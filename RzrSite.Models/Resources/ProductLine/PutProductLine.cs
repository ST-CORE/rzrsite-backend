using RzrSite.Models.Resources.ProductLine.Interfaces;

namespace RzrSite.Models.Resources.ProductLine
{
  public class PutProductLine: IPutProductLine
  {
    public string Path { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public bool IsShowOnMain { get; set; }
    public string FeaturesPDFPath { get; set; }
  }
}
