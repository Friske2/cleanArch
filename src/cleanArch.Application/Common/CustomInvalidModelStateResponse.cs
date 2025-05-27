using System;
using Microsoft.AspNetCore.Mvc;

namespace cleanArch.Application.Common;

public class CustomInvalidModelStateResponse
{
    public static IActionResult ProduceErrorResponse(ActionContext context)
    {
        var errors = context.ModelState
            .Where(ms => ms.Value.Errors.Count > 0)
            .Select(ms => new
            {
                field = ms.Key,
                messages = ms.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            });

        var result = new
        {
            status = 400,
            message = "Validation failed",
            errors = errors.SelectMany(e => e.messages).ToArray()
        };

        return new BadRequestObjectResult(result);
    }
}
