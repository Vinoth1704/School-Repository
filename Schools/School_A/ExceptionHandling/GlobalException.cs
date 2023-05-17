using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalException : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception.GetType();

        if (exception == typeof(ValidationException))
        {
            context.Result = new ObjectResult(new
            {
                Error = context.Exception.Message
            })
            {
                StatusCode = 400
            };
        }
        else
        {
            context.Result = new ObjectResult(new
            {
                Error = context.Exception.Message
            })
            {
                StatusCode = 500
            };
        }


    }
}