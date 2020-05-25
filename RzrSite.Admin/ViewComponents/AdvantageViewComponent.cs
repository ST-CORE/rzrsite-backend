using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.Advantage;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
  public class AdvantageViewComponent: ViewComponent
  {
    private readonly IAdvantageRepository _repo;

    public AdvantageViewComponent(IAdvantageRepository repo)
    {
      _repo = repo;
    }

    public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productLineId)
    {
      var advantages = await _repo.GetAdvantages(productLineId);
      var viewModel = new ListViewModel(advantages);
      viewModel.CategoryId = categoryId;
      viewModel.ProductLineId = productLineId;
      return View(viewModel);
    }
  }
}
