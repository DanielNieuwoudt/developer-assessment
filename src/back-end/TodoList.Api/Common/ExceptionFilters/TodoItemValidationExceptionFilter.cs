﻿using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoList.Api.Common.Features;
using TodoList.Api.Common.Constants;
using TodoList.Application.Common.Exceptions;

namespace TodoList.Api.Common.ExceptionFilters
{
    public class TodoItemValidationExceptionFilter : ExceptionFilterAttribute
    {
        private readonly Type _exceptionType = typeof(TodoItemValidationException);

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() != _exceptionType) return;

            context.HttpContext.Features.Set<IExceptionContextFeature>(new ExceptionContextFeature
            {
                ExceptionContext = context
            });

            var validationProblemDetails = new ValidationProblemDetails(context.ModelState);

            if (context.Exception is TodoItemValidationException exception)
            {
                foreach (var error in exception.Errors)
                {
                    validationProblemDetails.Errors.Add(error.PropertyName, [error.ErrorMessage]);
                }
            }

            context.Result = new BadRequestObjectResult(new Generated.BadRequest
            {
                Title = validationProblemDetails.Title!,
                Type = ResponseTypes.BadRequest,
                Status = (int)HttpStatusCode.BadRequest,
                Errors = validationProblemDetails.Errors.ToDictionary(
                    kvp => kvp.Key, 
                    kvp => kvp.Value.ToList()),
                TraceId = Activity.Current?.Id ?? string.Empty
            });

            context.ExceptionHandled = true;
        }
    }
}