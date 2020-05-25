using RzrSite.Models.Resources.DbFile;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.Files
{
  public class SelectViewModel
  {
    public IList<StrippedDbFile> Files { get; set; }
    public string AssignPathPrefix { get; set; }

    public SelectViewModel()
    {

    }

    public SelectViewModel(IList<StrippedDbFile> files, string assignPathPrefix)
    {
      Files = files ?? new List<StrippedDbFile>();

      if (!string.IsNullOrEmpty(assignPathPrefix))
      {
        AssignPathPrefix = assignPathPrefix;
      }
    }
  }
}
