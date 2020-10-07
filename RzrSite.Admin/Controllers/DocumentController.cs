using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repository;
using RzrSite.Admin.ViewModels.Document;
using System.Threading.Tasks;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Enums;
using RzrSite.Models.Resources.Documents;

namespace RzrSite.Admin.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDbFileRepository _repo;
        private readonly IProductLineRepository _productLineRepository;

        public DocumentController(IDbFileRepository repo, IProductLineRepository productLineRepository)
        {
            _repo = repo;
            _productLineRepository = productLineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int productLineId, int categoryId)
        {
            var files = await _repo.GetFileList();
            var pdfFiles = files.Where(x => x.Format == FileFormat.Pdf).ToList();
            return View(new DocumentViewModel(pdfFiles, categoryId, productLineId));
        }

        [HttpPost]
        public async Task<IActionResult> Add(DocumentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var files = await _repo.GetFileList();
                var pdfFiles = files.Where(x => x.Format == FileFormat.Pdf).ToList();
                model.Files = pdfFiles;
                return View(model);
            }

            await _productLineRepository.AddDocument(new PostDocument
            {
                Weight = model.Weight,
                FileId = model.FileId,
                Description = model.Description,
                ProductLineId = model.ProductLineId
            });

            return RedirectToAction("Edit", "ProductLine", new { categoryId = model.CategoryId, id = model.ProductLineId });
        }
    }
}
