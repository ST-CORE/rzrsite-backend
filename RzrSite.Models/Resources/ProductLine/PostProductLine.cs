using RzrSite.Models.Resources.ProductLine.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Resources.ProductLine
{
  public class PostProductLine : IPostProductLine
  {
	[Required]
	public string Path { get; set; }
	[Required]
	public string Name { get; set; }
	public string Description { get; set; }
	[Required]
	public int Weight { get; set; }
	public bool IsShowOnMain { get; set; }
	[Required]
	public string FeaturesPDFPath { get; set; }
  }
}
