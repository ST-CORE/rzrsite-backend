using System;

namespace RzrSite.Models.Exceptions
{
  public class DataNotFoundException : Exception
  {
    public DataNotFoundException(string message) : base(message)
    {
    }
  }
}
