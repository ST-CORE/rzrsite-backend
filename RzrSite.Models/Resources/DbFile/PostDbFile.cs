using RzrSite.Models.Enums;
using RzrSite.Models.Resources.DbFile.Interfaces;

namespace RzrSite.Models.Resources.DbFile
{
  public class PostDbFile: IPostDbFile
  {
    public FileFormat Format { get; set; }
    public string Path { get; set; }
    public byte[] Bytes { get; set; }
  }
}
