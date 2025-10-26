
namespace NotesForStudingAspDotNetCore.MiddleWaresNotes
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("MycustomMiddleware");
            await next(context);
            await context.Response.WriteAsync("MycustomMiddleware-2");
        }
    }

    public static class CustomMiddlewareExtension
    {
        // Static Function
        public static IApplicationBuilder UseMyCustomMiddleware (this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
