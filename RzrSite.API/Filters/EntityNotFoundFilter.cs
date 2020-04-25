using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RzrSite.DAL.Exceptions;

namespace RzrSite.API.Middleware
{
  public class EntityNotFoundFilter : IActionFilter, IOrderedFilter
  {
    public int Order { get; }

    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception is EntityNotFoundException ex)
      {
        context.Result = new ObjectResult(ex.Message)
        {
          StatusCode = 404
        };

        context.ExceptionHandled = true;
      }
    }
  }
}
