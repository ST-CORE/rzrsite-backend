using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace RzrSite.Admin.ViewModels.FeatureGroups
{
  public class FeatureList
  {
    public int FeatureTypeId { get; set; }
    public string FeatureTypeName { get; set; }
    public List<IFeature> Features { get; set; }
  }
}
