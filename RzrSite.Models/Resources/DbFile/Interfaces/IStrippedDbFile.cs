using RzrSite.Models.Enums;

namespace RzrSite.Models.Resources.DbFile.Interfaces
{
  public interface IStrippedDbFile
  {
    int Id { get; set; }
    string Path { get; set; }
    FileFormat Format { get; set; }
  }
}
