using RzrSite.Models.Responses.Advantage;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.Advantage
{
  public class ListViewModel
  {
    public IList<FullAdvantage> Advantages{ get; set; }
    public int CategoryId { get; set; }
    public int ProductLineId { get; set; }

    public ListViewModel()
    {

    }

    public ListViewModel(IList<FullAdvantage> advantages)
    {
      Advantages = advantages ?? new List<FullAdvantage>();
    }
  }
}
