using System.Net;
using TeledocTestTask.Domain.Exceptions;
using TeledocTestTask.Extensions;

namespace TeledocTestTask.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        public RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(BadRequestException ex)
            {
                await context.Response.HandleError(HttpStatusCode.BadRequest, ex.Message);
            }
            catch(NotFoundException ex)
            {
                await context.Response.HandleError(HttpStatusCode.NotFound, ex.Message);
            }
            catch(Exception ex)
            {
                await context.Response.HandleError(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
