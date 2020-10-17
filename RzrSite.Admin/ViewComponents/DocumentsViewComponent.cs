using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repositories.Interfaces;
using System.Threading.Tasks;
using RzrSite.Admin.Repository;
using RzrSite.Models.Responses.ProductLine;

namespace RzrSite.Admin.ViewComponents
{
    public class DocumentsViewComponent : ViewComponent
    {
        private readonly IProductLineRepository _repo;
        private readonly IDbFileRepository _dbFileRepository;

        public DocumentsViewComponent(IProductLineRepository repo, IDbFileRepository dbFileRepository)
        {
            _repo = repo;
            _dbFileRepository = dbFileRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productLineId)
        {
            var documents = (await _repo.GetProductLineDocuments(categoryId, productLineId)).ToList();

            foreach (var document in documents)
            {
                var m = (await _dbFileRepository.GetFile(document.FileId));
                document.FilePath = m?.Path;
            }

            return View(new ProductLineDocumentVm
            {
                Documents = documents,
                ProductLineId = productLineId,
                CategoryId = categoryId
            });
        }
    }
}
