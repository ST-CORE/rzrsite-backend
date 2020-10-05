using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using System.Threading.Tasks;

namespace RzrSite.Admin.ViewComponents
{
    public class DocumentsViewComponent : ViewComponent
    {
        private readonly IProductLineRepository _repo;

        public DocumentsViewComponent(IProductLineRepository repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productLineId)
        {
            var productLines = await _repo.GetProductLineDocuments(categoryId, productLineId);
            return View(productLines);
        }
    }
}
