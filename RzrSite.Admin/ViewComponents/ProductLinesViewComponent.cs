using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.ProductLines;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
  public class ProductLinesViewComponent: ViewComponent
  {
    private readonly IProductLineRepository _repo;

    public ProductLinesViewComponent(IProductLineRepository repo)
    {
      _repo = repo;
    }

    public async Task<IViewComponentResult> InvokeAsync(int categoryId)
    {
      var productLines = await _repo.GetProductLines(categoryId);
      var viewModel = new ListViewModel(productLines);
      viewModel.CategoryId = categoryId;
      return View(viewModel);
    }
  }
}
