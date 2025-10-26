# MiddleWares:
==> the component in the Application Pipeline to handle requests and 
responses.

==> chained one after other and execute in the same sequence.

  Middleware1 ==> Middleware2 ==> Middleware3
  (Single Op)     (Single Op)

# Pros of using Middlewares:
لو فيه عملية عاوز تحذفها / تشيلها من غير ما تأثر على الباقى يبقى تحذف ال 
middleware
الخاص بالعملية دى

# Can be wriiten in 2 ways:
1 - Anonymous Method / Lambda Expression
2 - Class

# Ex1:
app.Run(async (HttpContext Context) => {
	await Context.Response.writeAsync ("Hello")
});

# The Formula of Writing this Part:
app.Run(async (HttpContext Context) => {
	// Code
});

# The Extension Method Run in (app.Run) means:
 - Run is used to execute a (Short circuiting) middleware that doesn't 
   Forward the (Request الطلب طبعاا) to the (Next Middleware).

# Middleware Chaine Or Application-PipeLine
![Middleware Pipeline](Diagrams/MiddlewarePipeline.png)


# Note No.1:
By (Default) the middleware is of (Request Delegate) type.

# Custom Middleware Class:
==> Middleware class is used to ((separate)) the middleware logic (before/after logic)
from ((lambda expression)) to a separate / ((reusable class))

==> to define it as a class ==> First Thing is to (inherit from the predefined)
iterface called ((IMiddleware)) ==> this interface forces us to write one
method called InvokeAsync 

==> This InvokeAsync return a (task) type ==> that means it should be async method

==> This InvokeAsync Method receives 2 arguments 1- HttpContext
												 2- ResponseDelegate

==> When we add a custom middleware in the code the (Order) of 
middlewares is very important.

# Custom Middleware Extension:
==What is Extension Method?==
هوا طريقة تقدر تضيفها ظاهريا لأى نوع 
(class/struct/interface)
من غير ما تعدل فى الكود الأصلى فى النوع ده.

==> بتخليك تزود دوال جديدة على انواع موجودة بالفعل
زى الى موجودة فى ال 
String

==How to make or Write Extension Method ?==
1- The Function Should be Static.
2- It Must be in Static Class.
3- The First parameter in this function should be the kind that you want to add 
something to it. BUT it should written ==this== Before it.

Example of ordinary Extension Method:
+=========================================================+
public static class StringExtensions
{
    public static bool IsCapitalized(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

   return char.IsUpper(input[0]);
    }
}

string name = "Name";

bool result = name.IsCapitalized(); // كأنها دالة جوه string

+========================================================+

    In our Custom Middle ware      

app =Child of==>Build Method===child of==>Web Application Type =child of===> IApplicationBuilder

==> If you can ==inject== our extension Method into the ==IApplicationBuilder== it will be 
added into our ==app object== 

    InvokeAsync
Invoke ==> معناها انه بينفذ أو بيستدعى
InvokeAsync ==> The Method that ASP.Net Core bring it when the request REACHES my middleware in the pipeline.


# Custom Conventional Middleware Class:

المقصود هنا إنك إنت بنفسك بتعمل
Middleware
خاص بيك
(custom)

أى Middleware
إنت بتكتبه بنفسك وبتسجله فى
الـ pipeline بالطريقة التقليدية
app.UseMiddleware<>() EX
بيعتبر Custom Conventional Middleware.


==> You can create a custom middleware without inheriting form ==IMiddleware== iterface

==> In this case: Conventional Middleware:
We will receive ==next== as a constructor parameter
                     &&
We can get the ==HttpContext== parameter in this ==InvokeAsync== method.

==> In the ordinary Way:
We can see both next & HttpContext as parameters of InvokeAsync Method.

==> In this file "HelloCustomMiddleware.cs" :: We are not implementing IMiddleware
extension BUT we are going to use it as a custom middleware BY Convention.
By Maintaining some features

For Ex:

+========================================================+
 public class HelloCustomMiddleware  // Let's say this is a second middleware in the pipeline
 {
   private readonly RequestDelegate _next;

   public HelloCustomMiddleware(RequestDelegate next) 
   // So that middleware 3 (third) will be received as RequestDelegate Parameter here
 {
   _next = next;
 }
 .
 .
 .
  public Task Invoke(HttpContext httpContext)
  {
   // Before Logic
   return _next(httpContext);
   // After Logic
  }
+========================================================+

Note ==> There is built in Extension Method in the Middleware Class file that:
Extension method used to add the middleware to the HTTP request pipeline.

# Right Order of Middleware
Request 
   |
   V
1- Exception Handler  -- > Response                        |   ^
2- HSTS                                                    |   |
3- HttpsRedirection                                        |   |
4- Static Files                                            |   |
5- Routing                                                 |   |
6- CORS                                                    |   |
7- Authentication                                          |   |
8- Authorization                                           |   | 
9- Custom Middlewares (Custom1 -> Custom2 -> .....)        |   |
10-End Point                                               V   |


# Middleware -- Using When:

=== Request to/path ==> Middleware 1 In Main chain
                                    |
                                    V
                                 Use When
                         (Does the Condition True ?) == Yes => Middleware Branch
                                     |
                                     V
                                     No 
                        Middleware 2 - In Main Chain

