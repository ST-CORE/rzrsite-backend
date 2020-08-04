using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.Features;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
  public class FeatureViewComponent: ViewComponent
  {
    IFeatureRepository _repo { get; }
    IFeatureTypeRepository _fTypeRepo { get; }

    public FeatureViewComponent(IFeatureRepository repo, IFeatureTypeRepository fTypeRepo)
    {
      _repo = repo;
      _fTypeRepo = fTypeRepo;
    }

    public async Task<IViewComponentResult> InvokeAsync(int productId)
    {
      var features = await _repo.GetFeatures(productId);
      var featureTypes = await _fTypeRepo.GetAllFeatureTypes();

      var viewModel = new ListViewModel(productId, features, featureTypes);
      return View(viewModel);
    }
  }
}
