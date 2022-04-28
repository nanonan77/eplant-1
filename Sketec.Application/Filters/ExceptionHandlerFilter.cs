using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Sketec.Core.Exceptions;
using System;
using System.Linq;

namespace Sketec.Application.Filters
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        ILogger<ExceptionHandlerFilter> logger;
        public ExceptionHandlerFilter(ILogger<ExceptionHandlerFilter> logger)
        {
            this.logger = logger;
        }
        public bool AllowMultiple => throw new NotImplementedException();

        public void OnException(ExceptionContext context)
        {
            if (
                context.Exception is ApplicationException
                || context.Exception is DomainException
                || context.Exception is InfrastructureException)
            {
                logger.LogWarning($"Application Error: {context.Exception.Message} | User: {context.HttpContext.User.Identity.Name}");
                var exType = context.Exception.GetType();
                var json = new JsonResult(new
                {
                    message = context.Exception.Message,
                    type = exType.Name
                });

                json.StatusCode = 400;
                context.Result = json;
            }
            else if (
                context.Exception is SketecApplicationException)
            {
                var ex = (SketecApplicationException)context.Exception;
                logger.LogWarning($"Application Error: {context.Exception.Message} | Code: {ex.Code} | User: {context.HttpContext.User.Identity.Name}");
                var exType = context.Exception.GetType();
                var json = new JsonResult(new
                {
                    message = ex.Message,
                    code = ex.Code,
                    type = exType.Name
                });

                json.StatusCode = 400;

                context.Result = json;
            }
            else if (context.Exception is ValidationException)
            {
                var ex = (ValidationException)context.Exception;
                var first = ex.Errors.FirstOrDefault();
                logger.LogInformation($"Validate Error: {ex} | User: {context.HttpContext.User.Identity.Name}");
                var json = new JsonResult(new
                {
                    message = first?.ToString() ?? "Validation Error.",
                    errors = ex.Errors,
                    type = nameof(ex)
                });

                json.StatusCode = 400;

                context.Result = json;
            }
            else if (context.Exception is ArgumentException)
            {
                var argEx = (ArgumentException)context.Exception;
                logger.LogWarning($"Argument Error: {argEx} | User: {context.HttpContext.User.Identity.Name}");
                var json = new JsonResult(new
                {
                    message = argEx.Message,
                    paramName = argEx.ParamName,
                    type = nameof(ArgumentException)
                });

                json.StatusCode = 400;

                context.Result = json;
            }
            else
            {
                logger.LogError($"Server Error: {context.Exception} | User: {context.HttpContext.User.Identity.Name}");
                var json = new JsonResult(new
                {
                    message = context.Exception.ToString()
                });

                json.StatusCode = 500;

                context.Result = json;
            }
        }
    }
}
