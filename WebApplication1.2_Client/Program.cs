namespace WebApplication1._2_Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Map("/sum", builder =>
        {
            builder.Run(async context =>
            {
                if (context.Request.Method == "GET")
                {
                    var path = "Pages/staticFile.html";
                    context.Response.ContentType = "text/html";
                    await context.Response.SendFileAsync(path);
                }
                //else if (context.Request.Method == "POST")
                //{
                //    string x = context.Request.Headers["x"];
                //    string paramX = context.Request.Form["x"];
                //    string paramY = context.Request.Form["y"];

                //    int result = int.Parse(paramX) + int.Parse(paramY);
                //    int result2 = int.Parse(paramX) * int.Parse(paramY);

                //    context.Response.ContentType = "text/plain";
                //    await context.Response.WriteAsync(result.ToString() + " - " + result2.ToString());
                //}
            });

        });


        app.Run();
    }
}