using System;
using System.ComponentModel.DataAnnotations;

namespace RzrSite.Models.ValidationAttributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class UrlSafe : ValidationAttribute
  {
    public override bool IsValid(object value)
    {
      if (value == null || value.ToString() == string.Empty)
      {
        return true;
      }

      try
      {
        if (Uri.TryCreate(value.ToString(), UriKind.RelativeOrAbsolute, out _))
        {
            return true;
        }
      }
      catch
      {
        return false;
      }

      return false;
    }
  }
}
