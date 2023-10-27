using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();
app.MapGet("/", () => "Hello World!");

//http://localhost:5299/XYZ?ParmA=10&ParmB=15
app.MapGet("/XYZ", async context =>
{
    string paramA = context.Request.Query["ParmA"];
    string paramB = context.Request.Query["ParmB"];

    string response = $"GET-Http-XYZ: ParmA = {paramA}, ParmB = {paramB}";

    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(response);
});
app.MapPost("/XYZ", async context =>
{
    string paramA = context.Request.Query["ParmA"];
    string paramB = context.Request.Query["ParmB"];

    string response = $"POST-Http-XYZ: ParmA = {paramA}, ParmB = {paramB}";

    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(response);
});
app.MapPut("/XYZ", async context =>
{
    string paramA = context.Request.Query["ParmA"];
    string paramB = context.Request.Query["ParmB"];

    string response = $"PUT-Http-XYZ: ParmA = {paramA}, ParmB = {paramB}";

    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(response);
});


app.Map("/sum", builder =>
{
    builder.Run(async context =>
    {
        if (context.Request.Method == "GET")
        {
            Trace.WriteLine("process get");

            var path = "Pages/staticFile.html";
            context.Response.ContentType = "text/html";
            await context.Response.SendFileAsync(path);
        }
        else if (context.Request.Method == "POST")
        {
            Trace.WriteLine("process post");

            string x = context.Request.Headers["x"];
            string paramX = context.Request.Form["x"];
            string paramY = context.Request.Form["y"];

            Console.WriteLine("process form");


            int result = int.Parse(paramX) + int.Parse(paramY);
            int result2 = int.Parse(paramX) * int.Parse(paramY);

            context.Response.ContentType = "text/plain";

            //string redirectUrl = $"/process-form?result={result}&result2={result2}";
            //context.Response.Redirect(redirectUrl);
            await context.Response.WriteAsync(result.ToString() + " - " + result2.ToString());
        }
    });
    
});


app.MapGet("/process-form", async context =>
{
    Trace.WriteLine("process form");
    Console.WriteLine("process form");
    string result1 = context.Request.Query["result"];
    string result2 = context.Request.Query["result2"];

    // Process the data
    string result = $"Name: {result1}, Age: {result2}";

    await context.Response.WriteAsync($"Result: {result}");

});



app.Run();
