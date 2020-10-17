using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.Entities
{
  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  public class DbFile : IDbFile
  {
    [Key]
    public int Id { get; set; }
    public byte[] Bytes { get; set; }
    public string Path { get; set; }
    public FileFormat Format { get; set; }
  }
}
