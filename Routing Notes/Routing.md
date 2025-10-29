# Routing
## What is Routing ?
- **Invoking** the corresponding **endpoint** based on the **HTTP** method and **URL**.
- Routing is required to serve different pages to the client.
- Routing is automatically enabled when you write **builder.build** in the 
program.cs file.
- So No need for app.UseRouting() anymore.

User ==HttpRequest====> URL(if matched ?) =====> EndPoint (Actually middleware)
##### For Ex:
If the URL ==> /home ==> the client will go to the **Home page**
If the URL ==> /about ==> the client will go to the **About page**


###### Note:
In ASP.NET Core [Version 6] ==> Routing is automatically enabled &
The framework automatically handles the Routing Configuration.

## (Map Methods): Map - MapGet - MapPost 
The **Creation of the EndPoints** is by using the **map Methods**.

###### Note:
##### app.MapFallback();
It Will execute if the incoming request URL doesn't match with any of the routes or any paths.

###### Note:
Any Middleware you define using **app.use();** method will always run before the
routing endpoint execution.

##### For Post Request:
You have a **map.post();** it's for the post request only, So this more specific.
###### Ex:
- app.MapPost("map1", async (context) => {
    await context.Response.WriteAsync("In Map1");
});

##### For Get Request:
You have a **map.Get();** it's for the get request only, So this more specific.
###### Ex:
app.MapGet("map2", async(context) => {
    await context.Response.WriteAsync("In Map2");
}); // This Endpoint will be executed only if both the **Path="/map2"** and and the 
the Request Type is also **Get Request**.

## Route Parameters:
### We have 2 Somethings:
###### For Ex:
- We have ==> /files/sample.txt <br>
  /files/ ==> Fixed **Literal Particular Portion** <br>
  **Literal == Fixed value**
  /sample.txt OR {}.txt/ ==> Vary **Route parameter** <br>
  **Route parameter** ISNot Fixed. <br>

###### Note:
The Parts or whichever the segments can be vary ==> Create it as a parameter by using the braces <br>
Like ==> {} => This is braces
###### Ex:
- /employee/profile/Name
- /employee/prodile/{} // We replaced Name with {} as it varies.
##### So We have ways to write Routes using parameters:
- 1 - /files/{filename}.{extension} <br> // filename.txt
    {filename} & {extension} ==> **Parameters** <br>
    . ==> **Literal Text** <br>
        I want to return the values of the parameters:
        _____context.Request.RouteValues["filename"]; // For Ex.___
- 2 - /employee/profile/{employeename} <br>
    employee & extension ==> **Literal** <br>
    {exmplyeename} ==> **Parameter**.

##### Ex:
app.Map("files/{filename}.{extension}", async context => {
    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"In files - {filename} - {extension});
});
##### End of the Ex.

### Default Route Parameters:
==> In The Existing URLs, What exactly happens when you don't supply the values for the parameters?  *localhost:5000/textname.* <br>
Ans==> It will execute for the **fallback route**.








