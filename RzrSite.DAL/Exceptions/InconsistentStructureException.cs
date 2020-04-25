using System;

namespace RzrSite.DAL.Exceptions
{
  public class InconsistentStructureException: Exception
  {
    public InconsistentStructureException(string message) : base(message)
    {

    }
  }
}
