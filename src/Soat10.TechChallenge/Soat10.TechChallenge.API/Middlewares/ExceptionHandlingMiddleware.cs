using Soat10.TechChallenge.Application.Exceptions;
using System.Text.Json;

namespace Soat10.TechChallenge.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleCustomValidationExceptionAsync(context, ex);
            }
            catch (NotAllowedException ex)
            {
                await HandleForbidenAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }        

        private Task HandleCustomValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new
            {
                Title = "Erro de validação",
                Status = statusCode,
                ex.Errors
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private Task HandleForbidenAsync(HttpContext context, NotAllowedException ex)
        {
            int statusCode = StatusCodes.Status403Forbidden;
            string title = "Ação não permitida";
            return CreatResponseWithDetails(context, ex, title, statusCode);
        }


        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            string title = "Ocorreu um erro não tratado";
            return CreatResponseWithDetails(context, ex, title, statusCode);
        }
        private static Task CreatResponseWithDetails(HttpContext context, Exception ex, string title, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new
            {
                Title = title,
                Status = statusCode,
                Detail = ex.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
