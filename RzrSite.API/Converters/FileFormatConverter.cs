using RzrSite.API.Exceptions;
using RzrSite.Models.Enums;
using System;

namespace RzrSite.API.Converters
{
  public static class FileFormatConverter
  {
    public static string ToContentType(FileFormat format)
    {
      switch (format)
      {
        case FileFormat.Jpg:
          return "jpeg";
        case FileFormat.Pdf:
          return "pdf";
        case FileFormat.Png:
          return "png";
      }

      throw new UnknownContentTypeException($"Content type for format {Enum.GetName(typeof(FileFormat), format)} is unknown");
    }

    public static FileFormat FromString(string contentType)
    {
      switch (contentType)
      {
        case "jpeg":
          return FileFormat.Jpg;
        case "pdf":
          return FileFormat.Pdf;
        case "png":
          return FileFormat.Png;
      }
      throw new UnknownContentTypeException($"Content type :{contentType}: is unknown");
    }
  }
}
