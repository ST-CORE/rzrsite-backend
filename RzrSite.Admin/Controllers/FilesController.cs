using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repository;
using RzrSite.Admin.ViewModels.Files;
using RzrSite.Models.Converters;
using RzrSite.Models.Resources.DbFile;
using System.IO;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  public class FilesController: Controller
  {
    private const long MB30 = (30 * 1024 * 1024);
    private readonly IDbFileRepository _repo;

    public FilesController(IDbFileRepository repo)
    {
      _repo = repo;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var files = await _repo.GetFileList();
      return View(new IndexViewModel(files));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add(AddViewModel model)
    {
      var formFile = model.FormFile;
      if(formFile == null || formFile.Length <= 0)
        return await IndexWithError("Select some file!");

      if(formFile.Length > MB30)
        return await IndexWithError("File is bigger than 40mb!");

      if (!FileFormatConverter.KnownFormat(formFile.ContentType))
        return await IndexWithError($"{formFile.ContentType} is now known file format!");

      var newFile = new PostDbFile();

      using (var ms = new MemoryStream())
      {
        await formFile.CopyToAsync(ms);

        newFile.Bytes = ms.ToArray();
        newFile.Format = FileFormatConverter.FromString(formFile.ContentType);
      }

      var response = await _repo.AddFile(newFile);
      if (response.IsSuccess)
      {
        return RedirectToAction("Index");
      }

      return await IndexWithError(response.Message);
    }


    private async Task<ViewResult> IndexWithError(string error)
    {
      var files = await _repo.GetFileList();
      return View("Index", new IndexViewModel(files, error));
    }
  }
}
