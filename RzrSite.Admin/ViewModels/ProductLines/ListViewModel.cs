using RzrSite.Admin.Models;
using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.ProductLines
{
  public class ListViewModel
  {
    public IList<StrippedProductLine> ProductLines { get; set; }
    public int CategoryId { get; set; }

    public ListViewModel()
    {

    }

    public ListViewModel(IList<StrippedProductLine> productLines)
    {
      ProductLines = productLines ?? new List<StrippedProductLine>();
    }
  }
}
