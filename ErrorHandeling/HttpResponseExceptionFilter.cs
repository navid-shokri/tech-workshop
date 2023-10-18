using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandeling;

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is HttpResponseException httpResponseException)
        {
            context.Result = new ObjectResult(httpResponseException.Message)
            {
                StatusCode = httpResponseException.Code,
            };
            context.ExceptionHandled = true;
        }
    }
    public int Order=> int.MaxValue - 10; 
    
}