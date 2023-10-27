namespace _lab2a
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();


            app.Use(async (context, next) =>
            {
                if (context.Request.Path.ToString() == "/2")
                {
                    context.Response.Redirect("/index.html");
                }
                else
                {
                    await next();
                }
            });
            //3
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.ToString() == "/3")
                {
                    context.Response.Redirect("/Start/index");
                }
                else
                {
                    await next();
                }
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Start}/{action=index}/{id?}");

            //});


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Start}/{action=Index}/{id?}");

            app.Run();
        }
    }
}