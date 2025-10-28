# Routing
## What is Routing ?
- **Invoking** the corresponding **endpoint** based on the **HTTP** method and **URL**.
- Routing is required to serve different pages to the client.
- Routing is automatically enabled when you write **builder.build** in the 
program.cs file.
- So No need for app.UseRouting() anymore.

User ==HttpRequest====> URL(if matched ?) =====> EndPoint (Actually middleware)
###### For Ex:
If the URL ==> /home ==> the client will go to the **Home page**
If the URL ==> /about ==> the client will go to the **About page**


###### Note:
In ASP.NET Core [Version 6] ==> Routing is automatically enabled &
The framework automatically handles the Routing Configuration.

## (Map Methods): Map - MapGet - MapPost 
The **Creation of the EndPoints** is by using the **map Methods**.




