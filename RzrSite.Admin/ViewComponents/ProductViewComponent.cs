using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.ViewModels.Products;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
  public class ProductViewComponent: ViewComponent
  {
    private readonly IProductRepository _repo;

    public ProductViewComponent(IProductRepository repo)
    {
      _repo = repo;
    }

    public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productLineId)
    {
      var products = await _repo.GetProducts(categoryId, productLineId);
      var viewModel = new ListViewModel(products);
      viewModel.CategoryId = categoryId;
      viewModel.ProductLineId = productLineId;
      return View(viewModel);
    }

  }
}
