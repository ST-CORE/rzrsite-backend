using RzrSite.Models.Aggregations.Interfaces;
using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace RzrSite.Models.Aggregations
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class AggregatedFeature : IAggregatedFeature
  {
    public IFeatureType FeatureType { get; set; }
    public IDictionary<int, IFeature> FeatureByProductId { get; set; }
  }
}
