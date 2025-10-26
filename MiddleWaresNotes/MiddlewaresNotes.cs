using NotesForStudingAspDotNetCore.MiddleWaresNotes;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>(); // its very important to implement the custom middleware as class in our code
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello");
    await next(context);
});

// Middleware 2
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello Again");
});

// Custom middleware instead of the third middleware:
//First Way of Writing before using Extension Method
app.UseMiddleware<MyCustomMiddleware>();
//Second way of Writing after using Extension Method
app.UseMyCustomMiddleware();


app.Run();
