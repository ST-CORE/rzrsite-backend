using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.ProductLines
{
  public class IndexViewModel
  {
    public IDictionary<int, List<StrippedProductLine>> ProductLines { get; set; }
    public int CategoryId { get; set; }

    public IndexViewModel()
    {
      ProductLines = new Dictionary<int, List<StrippedProductLine>>();
    }
  }
}
