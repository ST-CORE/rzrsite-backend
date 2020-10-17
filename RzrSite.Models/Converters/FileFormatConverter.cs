using RzrSite.Models.Exceptions;
using RzrSite.Models.Enums;
using System;
using RzrSite.Models.Consts;

namespace RzrSite.Models.Converters
{
  public static class FileFormatConverter
  {
    public static string ToContentType(FileFormat format)
    {
      switch (format)
      {
        case FileFormat.Jpg:
          return KnownFormats.JPEG;
        case FileFormat.Pdf:
          return KnownFormats.PDF;
        case FileFormat.Png:
          return KnownFormats.PNG;
      }

      throw new UnknownContentTypeException($"Content type for format {Enum.GetName(typeof(FileFormat), format)} is unknown");
    }

    public static FileFormat FromString(string contentType)
    {
      switch (contentType)
      {
        case KnownFormats.JPEG:
          return FileFormat.Jpg;
        case KnownFormats.PDF:
          return FileFormat.Pdf;
        case KnownFormats.PNG:
          return FileFormat.Png;
      }
      throw new UnknownContentTypeException($"Content type :{contentType}: is unknown");
    }

    public static bool KnownFormat(string contentType)
    {
      switch (contentType)
      {
        case KnownFormats.JPEG:
          return true;
        case KnownFormats.PDF:
          return true;
        case KnownFormats.PNG:
          return true;
      }
      return false;
    }
  }
}
