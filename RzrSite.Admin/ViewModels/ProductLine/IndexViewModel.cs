using RzrSite.Admin.Models;
using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.ProductLine
{
  public class IndexViewModel
  {
    public IList<StrippedProductLine> ProductLines { get; set; }
    public int CategoryId { get; set; }
    public ErrorViewModel Error { get; set; }

    public IndexViewModel()
    {

    }

    public IndexViewModel(IList<StrippedProductLine> productLines) : this(productLines, null)
    {
    }

    public IndexViewModel(string error) : this(null, error)
    {
    }

    public IndexViewModel(IList<StrippedProductLine> productLines, string error)
    {
      ProductLines = productLines ?? new List<StrippedProductLine>();

      if (!string.IsNullOrEmpty(error))
      {
        Error = new ErrorViewModel
        {
          Error = error
        };
      }
    }
  }
}
