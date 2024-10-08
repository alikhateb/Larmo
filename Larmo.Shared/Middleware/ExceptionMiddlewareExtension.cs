﻿using Microsoft.AspNetCore.Builder;

namespace Larmo.Shared.Middleware;

public static class ExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}