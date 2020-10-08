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

        [HttpGet]
        public async Task<IActionResult> Edit(int id, int productLineId, int categoryId)
        {
            var document = await _productLineRepository.GetDocument(id);

            var file = await _repo.GetFile(document.FileId);

            return View(new DocumentViewModel
            {
                Weight = document.Weight,
                Description = document.Description,
                Id = document.Id,
                ProductLineId = productLineId,
                CategoryId = categoryId,
                FilePath = file.Path
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DocumentViewModel model)
        {
            await _productLineRepository.EditDocument(new PutDocument
            {
                Weight = model.Weight,
                Description = model.Description,
                Id = model.Id
            });

            return RedirectToAction("Edit", "ProductLine", new { categoryId = model.CategoryId, id = model.ProductLineId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int productLineId, int categoryId)
        {
            await _productLineRepository.DeleteDocument(id);

            return RedirectToAction("Edit", "ProductLine", new { categoryId = categoryId, id = productLineId });
        }
    }
}
