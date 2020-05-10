using System;

namespace RzrSite.Models.Exceptions
{
  public class UnknownContentTypeException : Exception
  {
    public UnknownContentTypeException(string message) : base(message)
    {

    }
  }
}
