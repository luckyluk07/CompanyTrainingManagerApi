﻿using CompanyTrainingManagerApi.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
              {
                await next.Invoke(context);
            }
            catch(NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch(BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch(ForbidException forbidException)
            {
                context.Response.StatusCode = 403;
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                //await context.Response.WriteAsync("Unexpected exception!");
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
