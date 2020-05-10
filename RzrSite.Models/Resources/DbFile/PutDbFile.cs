using RzrSite.Models.Resources.DbFile.Interfaces;

namespace RzrSite.Models.Resources.DbFile
{
  public class PutDbFile : IPutDbFile
  {
    public string Description { get; set; }
    public string Path { get; set; }
  }
}
