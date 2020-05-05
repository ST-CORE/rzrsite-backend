using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RzrSite.Admin.Repository;
using RzrSite.Models.Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Controllers
{
  public class FilesController: Controller
  {
    private readonly IDbFileRepository _repo;

    public FilesController(IDbFileRepository repo)
    {
      _repo = repo;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
      var files = await _repo.GetFileList();
      if(files == null)
      {
        files = new List<IDbFile>();
      }
      return View(files);
    }
  }
}
