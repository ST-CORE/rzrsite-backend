namespace RzrSite.Models.Responses.ProductLine
{
  public class StrippedProductLine
  {
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Path { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public bool IsShowOnMain { get; set; }
    public string FeaturesPDFPath { get; set; }
    public string LinkToVideo { get; set; }
  }
}
