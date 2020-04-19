using System;

namespace RzrSite.API.Exceptions
{
  public class UnknownContentTypeException : Exception
  {
    public UnknownContentTypeException(string message) : base(message)
    {

    }
  }
}
