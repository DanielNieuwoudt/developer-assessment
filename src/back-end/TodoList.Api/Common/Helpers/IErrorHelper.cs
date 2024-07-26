﻿using Microsoft.AspNetCore.Mvc;
using TodoList.Application.TodoItems.Errors;

namespace TodoList.Api.Common.Helpers;

public interface IErrorHelper
{
    BadRequestObjectResult DuplicateErrorResult(DuplicateError duplicateError);
    BadRequestObjectResult IdMismatchValidationError();
    NotFoundObjectResult NotFoundErrorResult(NotFoundError notFoundError);
    BadRequestObjectResult ValidationErrorResult(ValidationError validationError);
}