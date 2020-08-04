using RzrSite.Models.Entities;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.Features
{
  public class ListViewModel
  {
    public int ProductId { get; set; }
    public IList<Feature> Features { get; set; }
    public IList<FeatureType> FeatureTypes { get; set; }

    public ListViewModel()
    {

    }

    public ListViewModel(int productId, IList<Feature> features, IList<FeatureType> featureTypes)
    {
      Features = features;
      FeatureTypes = featureTypes;
      ProductId = productId;
    }
  }
}
