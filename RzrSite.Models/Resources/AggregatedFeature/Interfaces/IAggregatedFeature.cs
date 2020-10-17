using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace RzrSite.Models.Aggregations.Interfaces
{
  /// <summary>
  /// 
  /// </summary>
  public interface IAggregatedFeature
  {
    IFeatureType FeatureType { get; set; }
    IDictionary<int, IFeature> FeatureByProductId { get; set; }
  }
}