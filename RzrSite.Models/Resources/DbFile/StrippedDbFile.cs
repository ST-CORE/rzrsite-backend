using RzrSite.Models.Enums;
using RzrSite.Models.Resources.DbFile.Interfaces;

namespace RzrSite.Models.Resources.DbFile
{
  public class StrippedDbFile: IStrippedDbFile
  {
    public int Id { get; set; }
    public string Path { get; set; }
    public FileFormat Format { get; set; }
  }
}
