# Routing
## What is Routing ?
- Based on **HTTP** and **URL**
- **Invoking** the corresponding **endpoint** based on the **HTTP** method and **URL**.
- Routing is required to serve different pages **Endpoints** **to the client**.
- **Routing is automatically enabled** when you write **builder.build** in the 
program.cs file.
- So No need for app.UseRouting() anymore.

User ==HttpRequest====> URL(if matched ?) =====> EndPoint (Actually middleware)
##### For Ex:
- If the URL ==> /home ==> the client will go to the **Home page**
- If the URL ==> /about ==> the client will go to the **About page**
- So the important thing is **HTTP** and **URL**



###### Note:
In ASP.NET Core **[Version 6]** ==> Routing is automatically enabled &
The framework automatically handles the Routing Configuration.

## (Map Methods): Map - MapGet - MapPost (Creation of Endpoints)
The **Creation of the EndPoints** is by using the **map Methods**.

###### Note:
##### app.MapFallback();
It Will execute if the incoming request **URL doesn't match** with any of the routes or any paths.

###### Note:
Any Middleware you define using **app.use();** method will always run before the
routing endpoint execution.
- First Execution --> **app.use();**
- Second Execution --> **End Points Methods**.

##### For Post Request: (Read and take action) (Not in the cache Memory)
You have a **map.post();** it's for the post request only, So this more specific.
###### Ex:
- app.MapPost("map1", async (context) => {
    await context.Response.WriteAsync("In Map1");
});

##### For Get Request: (ReadOnly) (Stored in the Cache Memory)
You have a **map.Get();** it's for the get request only, So this more specific.
###### Ex:
app.MapGet("map2", async(context) => {
    await context.Response.WriteAsync("In Map2");
}); 
###### Note:
This Endpoint will be executed only if both the **Path="/map2"** and and the 
the Request Type is also **Get Request**.

## Route Parameters:
### We have 2 Somethings: 
#### 1- Literal Partical Portion (Fixed).
#### 2- Route Parameter (Varies).
###### For Ex:
- We have ==> /files/sample.txt <br>
  /files/ ==> Fixed **Literal Particular Portion** <br>
  **Literal == Fixed value**
  /sample.txt OR {}.txt/ ==> Vary **Route parameter** <br>
  **Route parameter** ISNot Fixed. <br>

###### Note:
The **Parts** or whichever the segments can be **vary** ==> Create it as a parameter **by using the braces** <br>
(Like) ==> {} => This is braces
###### Ex:
- /employee/profile/Name
- /employee/prodile/{} // We replaced Name with {} as it varies.
##### So We have ways to write Routes using parameters:
- 1 - /files/{filename}.{extension}  // filename.txt <br>
    {filename} & {extension} ==> **Parameters** <br>
    ((.)) ==> **Literal Text** <br>
    I want to return the **values** of the parameters: <br>
        _____context.Request.**RouteValues["filename"]**; // For Ex.___
- 2 - /employee/profile/{employeename} <br>
    employee & extension ==> **Literal** <br>
    {exmplyeename} ==> **Route Parameter**.

##### Ex:
app.Map("files/{filename}.{extension}", async context => {
    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"In files - {filename} - {extension});
});
##### End of the Ex.

### Default Route Parameters:
- In The Existing URLs, What exactly happens when you don't supply the values for the parameters?  *localhost:5000/textname.* 
- Like: The Correct way -> localhost:5000/textname/{id}/{name} 
- Ans==> It will execute for the **fallback route**.

### Optional Route Parameter:
- Something like that --> **"{parameter?}"** // **{id?}**
- "?" indicates optional parameter 
- That Means that it matches with **a value** from the user or **Empty Value** like **null** 
- The Default value is **null**
- In Real world Ex: If the value is not supplied, that means it is null value,
you may not retrieve the data form the database.

### Route Constraints:
- So in order to **specify restrictions on the parameters**, there is a concept
called **Constraints**.
- **How to write it ?** (like) -> {id:int?} // So the parameter **must** be **int** only.








