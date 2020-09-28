using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.Admin.ViewModels.FeatureGroups
{
  public class ListViewModel
  {
    public readonly int ProductLineId;
    public List<FeatureList> FeaturesByType { get; }
    public List<Product> Products { get; }

    public ListViewModel(IList<Product> products, IList<Feature> features, IList<FeatureType> featureTypes, int productLineId)
    {
      ProductLineId = productLineId;
      Products = products.OrderBy(p => p.Id).ToList();
      FeaturesByType = featureTypes.Select(ft => new FeatureList
      {
        Features = features.Where(f => f.TypeId == ft.Id).Select(p => p as IFeature).OrderBy(f => f.ProductId).ToList(),
        FeatureTypeId = ft.Id,
        FeatureTypeName = ft.Name
      }).ToList();

      foreach(var fType in FeaturesByType)
      {
        if (fType.Features.Count == Products.Count) continue;
        
        foreach(var product in Products.Where(p => fType.Features.All(f => f.ProductId != p.Id)))
        {
          fType.Features.Add(new Feature
          {
            Value = "0",
            TypeId = fType.FeatureTypeId,
            ProductId = product.Id
          });
        }

        features = features.OrderBy(f => f.ProductId).ToList();
      }
    }
  }
}
