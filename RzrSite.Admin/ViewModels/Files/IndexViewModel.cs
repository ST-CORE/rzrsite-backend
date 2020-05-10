using System.Collections.Generic;
using RzrSite.Admin.Models;
using RzrSite.Models.Resources.DbFile;

namespace RzrSite.Admin.ViewModels.Files
{
  public class IndexViewModel
  {
    public IList<StrippedDbFile> Files { get; set; }
    public ErrorViewModel Error { get; set; }

    public IndexViewModel()
    {

    }

    public IndexViewModel(IList<StrippedDbFile> files) : this(files, null)
    {
    }

    public IndexViewModel(string error) : this(null, error)
    {
    }

    public IndexViewModel(IList<StrippedDbFile> files, string error)
    {
      Files = files ?? new List<StrippedDbFile>();

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
