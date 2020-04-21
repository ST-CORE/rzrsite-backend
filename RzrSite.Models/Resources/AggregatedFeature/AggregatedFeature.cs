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


  //public IList<IAggregatedFeature> AgregateFeatures(int seriesId)
  //{
  //  var features = Products.SelectMany(p => p.Features);
  //  var comparer = new FeatureTypeComparer();
  //  var featureTypes = features.GroupBy(p => p.Type, comparer);
  //  var result = new List<IAggregatedFeature>();

  //  foreach (var featureGroup in featureTypes)
  //  {
  //    var aggregatedFeature = new AggregatedFeature
  //    {
  //      FeatureType = featureGroup.Key,
  //      FeatureByProductId = new Dictionary<int, IFeature>(featureGroup.Select(f => new KeyValuePair<int, IFeature>(f.ProductId, f)))
  //    };

  //    result.Add(aggregatedFeature);
  //  }

  //  return result;
  //}
}
