using RzrSite.Models.Enums;

namespace RzrSite.Models.Resources.DbFile.Interfaces
{
  public interface IPostDbFile
  {
    FileFormat Format { get; set; }
    public byte[] Data { get; set; }
  }
}
