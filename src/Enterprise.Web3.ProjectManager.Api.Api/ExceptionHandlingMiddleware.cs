using Enterprise.Web3.ProjectManager.Api.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Api
{
    /// <summary>
    /// Пайп ASP.NET Core для обработки исключений
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="next">Делегат следующего обработчика в пайплайне</param>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Обработать запрос
        /// </summary>
        /// <param name="context">Контекст</param>
        /// <returns>-</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ApplicationExceptionBase ex)
            {
                var message = JsonSerializer.Serialize(new
                {
                    Message = ex.Message
                });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(message);
            }
            catch (Exception ex)
            {
                var message = JsonSerializer.Serialize(new
                {
                    Message = ex.Message
                });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(message);
            }
        }
    }
}
