using EPizzaHub.Core.CustomExceptions;
using EPizzaHub.Models.Response;
using System.Security.Authentication;
using System.Text.Json;

namespace EPizzaHub.API.Middleware
{
    public class CommonResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public CommonResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var orginalbodystream = context.Response.Body;

            using (var MemoryStream = new MemoryStream())
            {
                context.Response.Body = MemoryStream;

                try
                {
                    await _next(context);

                    if (context.Response.ContentType != null
                        && context.Response.ContentType.Contains("application/json"))
                    {
                        MemoryStream.Seek(0, SeekOrigin.Begin);

                        var responseBody = await new StreamReader(MemoryStream).ReadToEndAsync();

                        var responseObj = new ApiResponseModel<object>(
                            success: context.Response.StatusCode >= 200 && context.Response.StatusCode <= 300,
                            data: JsonSerializer.Deserialize<object>(responseBody)!,
                            message: "Request completed Successfully"

                            );

                        var JsonResponse = JsonSerializer.Serialize(responseObj);
                        context.Response.Body = orginalbodystream;
                        await context.Response.WriteAsync(JsonResponse);
                    }

                }
                catch (InvalidCredentialException ex)
                {
                    context.Response.StatusCode = 401;
                    var errorResponse = new
                    {
                        success = false,
                        data = (object)null,
                        message = ex.Message
                    };
                    var jsonResponse = JsonSerializer.Serialize(errorResponse);
                    context.Response.Body = orginalbodystream;
                    await context.Response.WriteAsync(jsonResponse);
                }
                catch (RecordNotFoundException ex)
                {
                    context.Response.StatusCode = 400;
                    var errorResponse = new
                    {
                        success = false,
                        data = (object)null,
                        message = ex.Message
                    };
                    var jsonResponse = JsonSerializer.Serialize(errorResponse);
                    context.Response.Body = orginalbodystream;
                    await context.Response.WriteAsync(jsonResponse);
                }
                catch (Exception ex)
                {
                    //throw ex;

                    context.Response.StatusCode = 500;
                    var errorResponse = new
                    {
                        success = false,
                        data = (object)null,
                        message = ex.Message,
                    };
                    var JsonResponse = JsonSerializer.Serialize(errorResponse);
                    context.Response.Body = orginalbodystream;
                    await context.Response.WriteAsync(JsonResponse);
                }
            }


        }

    }
}
