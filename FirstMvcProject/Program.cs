using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Routing.Constraints;
using static System.Net.Mime.MediaTypeNames;

namespace FirstMvcProject
{

    #region Routing Notes
    //Routing is a pattern matching system
    //Routing maps requests to appropriate Controller and Action Method
    //its allows the framework understand which part is excuted
    //Route Goes to the first match 
    //Types Of Routing 
    //1)Convention Based Routing (Traditional Routing)
    //2)Attribute Based Routing 
    //The specific Route is Excuted before the general Route (The test & {name}) EX 
    //Sort my Routes from the most specific to the most general 
    #endregion
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configurations [DI]
            builder.Services.AddControllersWithViews();
            #endregion

            var app= builder.Build();
            #region Configure Http Request
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //This is what allows me to use routing and use endpoints
            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            #endregion
            //This is shorter syntax for the previous use end points do the same thing
            //app.MapGet("/", async context =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            #region Routing
            //app.MapGet("/test", async context => //Fixed Segment
            //{ 
            //    await context.Response.WriteAsync("Hello test!");
            //});

            // app.MapGet(pattern: "/{name}", requestDelegate: async context => //Variable Segment
            //{
            //    var name = context.GetRouteValue("name"); //Here this line allows to understand name in the next line 
            //    await context.Response.WriteAsync($"Hello {name}!"); //Here is doenst understand the name
            //});
            //app.MapGet(pattern: "/Fixed{name}", requestDelegate: async context => //Mixed Segment
            //{
            //    var name = context.GetRouteValue("name"); 
            //    await context.Response.WriteAsync($"Hello fixed {name}!");
            //});

            //Another syntax
            //app.MapGet(pattern: "/Fixed{name}", requestDelegate: async context => //Mixed Segment
            //            {
            //                var name = context.Request.RouteValues["name"]; //here its brackets not prathes
            //                await context.Response.WriteAsync($"Hello fixed {name}!");
            //            });

            //The name is only for understanding doesnt affect the proccess
            app.MapControllerRoute(
                name: "JO",
                //here i added the name and note that i have to add the (?) to the id to work properly 
                //or i can remove the name and the url be like this https://localhost:7120/movies/Getmovie/55?name=ccc  and work 
                pattern: "{Controller}/{action}/{id?}"//here i set a default values for the controller and the action
                                                                     //constraints: new { id = new IntRouteConstraint() }
                /*constraints: new { id = @"^\d{2}" }*/ //to force that the id two digits
                );



            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{Controller}/{action}/{id:int?}", //here the id is optional (?)
            //    defaults:new {controller="Movies" , action ="Index"},   //if it provide the id the previous controller will be triggered 
            //                                                            //if it doesnt provide id this controller will be triggered
            //    constraints : new {id = new IntRouteConstraint()}   //it forces the id to be int  
            //in the constrains alpha for the string 
            //{id:int?} to replace the constrains
            //);
            // app.MapGet(pattern: "/Movie/GetMovie", requestDelegate: async context => //Variable Segment
            //{
            //    await context.Response.WriteAsync($"Hello {name}!");
            //});

            #region Action Result  & Action Return Type
            //Action Returns in response to a browser request 
            //The ASP.NET MVC framework supports several types of action results including:
            //1-ViewResult - Represents HTML and markup.
            //2-EmptyResult - Represents no result.
            //3-RedirectResult - Represents a redirection to a new URL.
            //4-JsonResult - Represents a JavaScript Object Notation result that can be used in an AJAX application.
            //5-JavaScriptResult - Represents a JavaScript script.
            //6-ContentResult - Represents a text result.
            //7-FileContentResult - Represents a downloadable file(with the binary content).
            //8-FilePathResult - Represents a downloadable file(with a path).
            //9-FileStreamResult - Represents a downloadable file(with a file stream).

            //In most Cases Action Returns ViewResult
            #endregion


            #region Model Binding
            //HTTP://URL/SEGMENT /{SEGMENT} /X{SEGMENT}
            //            STATIC  VARIABLE   MIXED
            //Have to takecare of the
            //1-Order of the segments 
            //2-No of segments 
            //3-Defaults 
            //4-Constrains

            //Model binding automates the proccess like (route data , posted form fields) 
            //The value providers (the order matters)
            //1-Form
            //2-Request Body
            //3-Route Data
            //4-Query String 
            //5-Request Header

            //value Types 
            //Simple data (name)
            //Complex Data (object.attribute)
            //Mixed Data (Any Match)
            //Collection ([Index])

            #endregion
            #endregion




            app.Run();
        }
    }
}
