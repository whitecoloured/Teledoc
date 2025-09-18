using System.Net;

namespace TeledocTestTask.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static async Task HandleError(this HttpResponse response, HttpStatusCode statusCode, string message)
        {
            int codeNumber = (int)statusCode;
            response.StatusCode = codeNumber;
            response.ContentType = "application/json";
            await response.WriteAsJsonAsync(new {Code = codeNumber, Message = message} );
        }
    }
}
