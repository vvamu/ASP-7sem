using Microsoft.AspNetCore.Mvc;
using System;

namespace lab2b
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            #region 

            app.MapGet("/TMResearch", context =>
            {
                // Handle the /TMResearch URI here by calling the MO1 action method.
                return context.Response.WriteAsync("GET:M01");
            });

            app.MapGet("/", context => context.Response.WriteAsync("GET:M01"));
            app.MapGet("/V2", context => context.Response.WriteAsync("GET:M02"));

            app.MapGet("/V2/TMResearch", context => context.Response.WriteAsync("GET:M02"));
            app.MapGet("/V3", context => context.Response.WriteAsync("GET:M03"));
            app.MapGet("/V3/TMResearch/string/", context => context.Response.WriteAsync("GET:M03"));
            #endregion

            app.UseAuthorization();


            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=TMResearch}/{action=MO1}/{id?}");


            app.MapControllerRoute(
               name: "V2",
              pattern: "V2/{controller=TMResearch}/{action=MO2}/{id?}"
            );
            app.MapControllerRoute(
              name: "V3",
             pattern: "V3/{controller=TMResearch}/{str?}/{action=MO3}"
            );
            
            app.MapFallbackToController("MXX", "TMResearch");

            

            app.Run();
        }
    }
}