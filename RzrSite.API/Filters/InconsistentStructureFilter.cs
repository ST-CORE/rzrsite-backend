using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RzrSite.DAL.Exceptions;

namespace RzrSite.API.Filters
{
  public class InconsistentStructureFilter : IActionFilter, IOrderedFilter
  {
    public int Order { get; }

    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception is InconsistentStructureException ex)
      {
        context.Result = new ObjectResult(ex.Message)
        {
          StatusCode = 400
        };

        context.ExceptionHandled = true;
      }
    }
  }
}
