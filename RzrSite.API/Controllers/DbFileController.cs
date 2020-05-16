using Microsoft.AspNetCore.Mvc;
using RzrSite.API.Responses.DbFile;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Converters;
using RzrSite.Models.Resources.DbFile;
using System;

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
    public IActionResult Get()
    {
      var response = _repo.GetAll();
      return Ok(response);
    }

    [HttpGet("/api/Storage/{*path}")]
    public IActionResult Storage(string path)
    {
      var dbFile = _repo.Get(path);
      if(dbFile == null)
      {
        return NotFound();
      }
      return File(dbFile.Bytes, FileFormatConverter.ToContentType(dbFile.Format));
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var response = _repo.Get(id);
      return Ok(response);
    }

    [HttpPost]
    public IActionResult Post([FromBody]PostDbFile file)
    {
      if (file.Bytes.Length > MB30)
        return BadRequest("Provided file is larger than 30 MB");
      
      try
      {
        var id = _repo.Add(file);
        return Ok(new AddedDbFile(id.GetValueOrDefault()));
      }
      catch(Exception ex)
      {
        throw ex;
      }
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]PutDbFile file)
    {
      var updatedFile = _repo.Update(id, file);

      return Ok(updatedFile);
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _repo.Delete(id);

      if (result)
      {
        return Ok();
      }
      else
      {
        return BadRequest("Something went wrong!");
      }
    }
  }
}
