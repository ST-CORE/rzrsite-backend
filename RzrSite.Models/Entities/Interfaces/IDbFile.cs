using RzrSite.Models.Enums;

namespace RzrSite.Models.Entities.Interfaces
{
  public interface IDbFile
  {
    int Id { get; set; }
    byte[] Bytes { get; set; }
    string Path { get; set; }
    FileFormat Format { get; set; }
  }
}