using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RzrSite.API.Responses.DbFile;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.DbFile;
using System.Threading.Tasks;

namespace RzrSite.API.Controllers
{
  [Route("/api/dbfile")]
  public class DbFileController: ControllerBase
  {
    private const long MB30 = (30 * 1024 * 1024);
    private readonly IDbFileRepo _repo;

    public DbFileController(IDbFileRepo repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> AllFiles()
    {
      var response = _repo.GetAll();
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddFile([FromBody]PostDbFile file)
    {
      if (file.Bytes.Length > MB30)
        return BadRequest("Provided file is larger than 30 MB");

      var id = _repo.Add(file);

      return Ok(new AddedDbFile(id.GetValueOrDefault()));
    }
  }
}
