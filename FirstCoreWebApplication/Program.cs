using System;

namespace FirstCoreWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            ////Configuring Middleware Component using Use and Run Extension Method
            ////First Middleware Component Registered using Use Extension Method
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middleware1: Incoming Request\n");
            //    //Calling the Next Middleware Component
            //    await next();
            //    await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
            //});
            ////Second Middleware Component Registered using Use Extension Method
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middleware2: Incoming Request\n");
            //    //Calling the Next Middleware Component
            //    await next();
            //    await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
            //});
            ////Third Middleware Component Registered using Run Extension Method
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Middleware3: Incoming Request handled and response generated\n");
            //    //Terminal Middleware Component i.e. cannot call the Next Component
            //});

            // Enable directory browsing on the current path
            //app.UseDirectoryBrowser();

            //Setting the Default Files
            //app.UseDefaultFiles();

            //Adding Static Files Middleware Component to serve the static files
            //app.UseStaticFiles();

            //Adding Another Terminal Middleware Component to the Request Processing Pipeline
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Request Handled and Response Generated");
            //});

            if (app.Environment.IsDevelopment()) 
            { 
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                { 
                    SourceCodeLineCount = 5
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }


            app.MapGet("/", async context =>
            {
                int Number1 = 10, Number2 = 0;
                int Result = Number1 / Number2; //This statement will throw Runtime Exception
                await context.Response.WriteAsync($"Result : {Result}");
            });
            //This will Run the Application


            //This will Start the Application
            app.Run();
        }

    }
}
