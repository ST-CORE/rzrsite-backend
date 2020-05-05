using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RzrSite.API.Converters;
using RzrSite.API.Responses.DbFile;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Resources.DbFile;
using System.IO;
using System.Threading.Tasks;

namespace RzrSite.API.Controllers
{
  public class DbFileController: ControllerBase
  {
    private const long MB30 = (30 * 1024 * 1024);
    private readonly IDbFileRepo _repo;

    public DbFileController(IDbFileRepo repo)
    {
      _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> AddFile(FormFile file)
    {
      if (file.Length > MB30)
        return BadRequest("Provided file is larger than 30 MB");

      int? id;
      using(var memoryStream = new MemoryStream())
      {
        await file.CopyToAsync(memoryStream);
        id = _repo.Add(new PostDbFile
        {
          Data = memoryStream.ToArray(),
          Format = FileFormatConverter.FromString(file.ContentType)
        });
      }

      return Ok(new AddedDbFile(id.GetValueOrDefault()));
    }
  }
}
