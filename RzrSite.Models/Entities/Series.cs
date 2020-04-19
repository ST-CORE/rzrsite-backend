using RzrSite.Models.Aggregations;
using RzrSite.Models.Aggregations.Interfaces;
using RzrSite.Models.Comparers;
using RzrSite.Models.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class Series : ISeries
  {
    [Key]
    public int Id { get; set; }
    public string Path { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public IList<IAdvantage> Advantages { get; set; }
    public IList<IDocument> Documents { get; set; }
    public IList<IProduct> Products { get; set; }

    public IList<IAggregatedFeature> AgregateFeatures()
    {
      var features = Products.SelectMany(p => p.Features);
      var comparer = new FeatureTypeComparer();
      var featureTypes = features.GroupBy(p => p.Type, comparer);
      var result = new List<IAggregatedFeature>();

      foreach (var featureGroup in featureTypes)
      {
        var aggregatedFeature = new AggregatedFeature
        {
          FeatureType = featureGroup.Key,
          FeatureByProductId = new Dictionary<int, IFeature>(featureGroup.Select(f => new KeyValuePair<int, IFeature>(f.ProductId, f)))
        };

        result.Add(aggregatedFeature);
      }

      return result;
    }
  }
}
