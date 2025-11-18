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
- Of the Route Constraints is **decimal** or **long** or  **guid** 
- **So what is guid ?** It is **Globally Unique Identifier** or we can say 
**A hexadecimal Number** that is universally unique.
- **guid** like int , long , string and so on.
#### How to Generate guid yourself ?
- In visual studio **tools menu**
- Create Guid
- Select the Forth option.

#### There are another Route Constraints:
- **minlength(value)** ==> Matches with a string that has **at least** specified
number of characters.
###### Ex:
    {username:minlength(4)} matches with ((John, Allen, William)). // 4 or above
- **maxlength(value)** ==> Matches with a string that has less than or equal to 
the specified number of characters.
###### Ex:
    {username:maxlength(7)} matches with ((John, Allen, William)). // 7 or less
- **length(min,max)** ==> Matches with a string that has number of characters 
between given min and max length (both numbers including).
##### Like also with integer values (numbers):
- length(value) --> {tin:length(9)}
- min(value)    --> {age:min(18)}
- max(value)    --> {age:max(100)}  
- range(min,max)--> {age:range(19,100)}
- alpha
- regex (expression)
#### Regular Expressions in Route Constraints:
- ((Like)) --> **apr or jul or oct or jan**
###### Ex:
app.map("sales-report/{year:int:min(1900)}/{month:**regex(^(apr|jul|oct)$)**}")
- Format of Regular Expression --> :regex(**^(-----)$**)

### Custom Route Constraints:
- The Custom Constraint works equivalent to a normal constraint, but instead
of a simple constraint, **It would be a class**.
- **Custom Route Constraints Class** : It implements an interface called 
**IRouteConstraint** so that **this interface roles** that you have to
**define a Method called match** so that this particular match method will
be executed in order to **verify** whenever **the incoming request matches**
or **not**.
- **Optionally**, you can place all of your custom constraints in separate in 
a **separate folder**.
- after we make a separate folder and a file in it.
- In this file we have
    ###### This Code:
    namespace RoutingExample.CustomConstraints; <br>
    // As of Now it is a *normal simple class* to convert the same into a constraint *by* **Implement** the **interface** called **IRouteConstraint** <br>
    // We can see the definition of this Interface by **Right Click**. <br>
    // **Why we see the Definition of the Interface ?** <br>
        So We have to write the same method in my own class. <br>
    public class MonthsCustomConstraint : IRouteConstraint <br>
    { <br>
        ..The Method of Implementation the **interface**... <br>
        //This Method will Automatically be executed as soon as an 
        incoming request is received <br>
    } <br>
###### Ex:
// Implementation of the interface <br>
public class ClassName : IRouteConstraint <br>
{ <br>
    // method <br>
    public bool Match() <br>
} <br>
#### How to Implement Automatically the Interfernce ?
- Right Click on this Interface.
- Quick Actions and Refactorings
- Select **Implement Interface**
#### What is your hands is that the code in this Method:
- Remove this **throw statement** and write my own code.
#### Parameters of this Method:
- httpContext: is the **context** that we are **receiving** in the **middleware** So this context provides the **request** and **response** objects mainly.
- IRouter? route : this a **type of a parameter** represents **an object** that represents the route. 
#### How to create a Regular Expression ?
- We have already a **class** called **Regex** in C# itself, You can use it every 
where.
- **Regex*** --> for **Regular Expression**.
- In order to use that, you require to **import** our **namespace** in the same file. 
- ![Regex To Create Regular Expression](Diagrams/RegexForRegularEx.png)
#### To add the Custom Route Constraint:
- builder.Services.AddRouting(options => { <br>
    options.ConstraintMap.Add("months", typeof(**The Class of Custom Constraint**)) <br>
    }) <br>
- **months** is instead of **regex(**^(-----)$**)**

## End Point Selection Order:
- If the Same incoming url matches with more than one route, then which route will be picked up ?
- It should not based on the order, but it is based on certain Rules.
    - 1 - URL template with more segemnts
        ###### Ex: "a/b/c/d" is higher than "a/b/c"
    - 2 - URL template with literal(Fixed) text has more precedence than a parameter segment.
        ###### Ex: "a/b" is higher than "a/{parameter}"
    - 3 - URL template that has a parameter segment with constraints has more precedence than a parameter segment without constraints.
        ###### Ex: "a/{b:int}" is higher than "a/{b}"
    - 4 - Catch-all parameters(**)
        ###### Ex: "a/{b}" is higher than "a/**"

## WebRoot and UseStaticFiles(): 












