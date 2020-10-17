using RzrSite.Models.Resources.DbFile;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.Files
{
  public class SelectViewModel
  {
    public IList<StrippedDbFile> Files { get; set; }
    public string FirstButtonPrefix { get; set; }
    public string SecondButtonPrefix { get; set; }

    public SelectViewModel()
    {

    }

    public SelectViewModel(IList<StrippedDbFile> files, string firstButtonPrefix, string secondButtonPrefix)
    {
      Files = files ?? new List<StrippedDbFile>();

      if (!string.IsNullOrEmpty(firstButtonPrefix))
      {
        FirstButtonPrefix = firstButtonPrefix;
      }

      if (!string.IsNullOrEmpty(secondButtonPrefix))
      {
        SecondButtonPrefix = secondButtonPrefix;
      }
    }
  }
}
