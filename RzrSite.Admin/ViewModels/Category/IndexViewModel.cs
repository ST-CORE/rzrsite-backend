using RzrSite.Admin.Models;
using RzrSite.Models.Responses.Category;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.Category
{
  public class IndexViewModel
  {
    public IList<StrippedCategory> Categories { get; set; }
    public ErrorViewModel Error { get; set; }

    public IndexViewModel()
    {

    }

    public IndexViewModel(IList<StrippedCategory> categories) : this(categories, null)
    {
    }

    public IndexViewModel(string error) : this(null, error)
    {
    }

    public IndexViewModel(IList<StrippedCategory> categories, string error)
    {
      Categories = categories ?? new List<StrippedCategory>();

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
