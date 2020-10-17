using RzrSite.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.API.Models
{
    public class ProductFeatureTableModel
    {
        public int CategoryId { get; set; }
        public int ProductLineId { get; set; }
        public List<FeatureList> FeaturesByType { get; }
        public List<Product> Products { get; }

        public ProductFeatureTableModel(IEnumerable<Product> products, IList<Feature> features, IEnumerable<FeatureType> featureTypes, int productLineId, int categoryId)
        {
            ProductLineId = productLineId;
            CategoryId = categoryId;
            Products = products.OrderBy(p => p.Id).ToList();
            FeaturesByType = featureTypes.Select(ft => new FeatureList
            {
                Features = features.Where(f => f.TypeId == ft.Id).Select(p => p).OrderBy(f => f.ProductId).ToList(),
                FeatureTypeId = ft.Id,
                FeatureTypeName = ft.Name
            }).ToList();

            foreach (var fType in FeaturesByType)
            {
                if (fType.Features.Count == Products.Count) continue;

                foreach (var product in Products.Where(p => fType.Features.All(f => f.ProductId != p.Id)))
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
