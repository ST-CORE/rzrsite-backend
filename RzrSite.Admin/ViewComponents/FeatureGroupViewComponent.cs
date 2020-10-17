using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.FeatureGroups;
using RzrSite.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using RzrSite.Models.Resources.Feature;

namespace RzrSite.Admin.ViewComponents
{
    public class FeatureGroupViewComponent : ViewComponent
    {
        IFeatureRepository _repoFeature { get; }
        IFeatureTypeRepository _fTypeRepo { get; }
        IProductRepository _productRepo { get; }


        public FeatureGroupViewComponent(IFeatureRepository repo, IFeatureTypeRepository fTypeRepo, IProductRepository productRepo)
        {
            _repoFeature = repo;
            _fTypeRepo = fTypeRepo;
            _productRepo = productRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productLineId)
        {
            var featureTypes = await _fTypeRepo.GetAllFeatureTypes(categoryId);
            var products = await _productRepo.GetProducts(categoryId, productLineId);
            var features = new List<Feature>();
            foreach (var product in products)
            {
                var prodFeatures = await _repoFeature.GetFeatures(product.Id);
                if (prodFeatures != null)
                {
                    features.AddRange(prodFeatures);
                }
            }
            var viewModel = new ListViewModel(products, features, featureTypes, productLineId, categoryId);
            return View(viewModel);
        }
    }
}
