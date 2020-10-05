using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repository;
using RzrSite.Admin.ViewModels.Files;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private const long Mb30 = (30 * 1024 * 1024);
        private readonly IDbFileRepository _repo;

        public DocumentController(IDbFileRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var files = await _repo.GetFileList();
            return View(new IndexViewModel(files));
        }
        
    }
}
