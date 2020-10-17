using RzrSite.Models.Entities;
using System.Collections.Generic;


namespace RzrSite.Admin.ViewModels.Products
{
  public class ListViewModel
  {
    public IList<Product> Products { get; set; }
    public int CategoryId { get; set; }
    public int ProductLineId { get; set; }

    public ListViewModel()
    {

    }

    public ListViewModel(IList<Product> products)
    {
      Products = products ?? new List<Product>();
    }
  }
}
