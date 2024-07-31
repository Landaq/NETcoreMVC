using FluentAPIDemo.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace FluentAPIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Enables integration between FluentValidation and ASP.NET MVC's automatic validation pipeline.
            builder.Services.AddFluentValidationAutoValidation();

            // Enables integration between FluentValidation and ASP.NET client-side validation.
            builder.Services.AddFluentValidationClientsideAdapters();

            // Registering Model and Validator to show the error message on client side
            builder.Services.AddTransient<IValidator<RegistrationModel>, RegistrationValidator>()
                            .AddTransient<IValidator<Product>, ProductValidator>()
                            .AddTransient<IValidator<Cart>, CartValidator>()
                            .AddTransient<IValidator<PaymentInfo>, PaymentInfoValidator>()
                            .AddTransient<IValidator<Event>, EventValidator>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
