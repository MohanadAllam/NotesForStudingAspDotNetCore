using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); // Here Routing the automatically Enabled

// First EndPoint
/* If the incoming request URL matches with this URL, then we are going to provide 
a REQUEST DELEGATE means a middleware that can receive the context as argument */
// Request Delegate ==> (context) => {};
app.Map("map1", async (context) =>
{
    await context.Response.WriteAsync("In Map 1");
});

app.Map("map2", async (context) =>
{
    await context.Response.WriteAsync("In Map 2");
});

app.Run();
