using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.DateTime;


namespace PracticalAspNetCore
{
    public class Startup
    {

        /// <summary>
        /// Give English time of day rather than say Hello World.
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context => 
                await context.Response.WriteAsync($"{TimeOfDay()}"));
        }

        public string TimeOfDay() =>
            Now.Hour switch
            {
                <= 12 => "Good Morning",
                <= 16 => "Good Afternoon",
                <= 20 => "Good Evening",
                _ => "Good Night"
            };
    }

    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>()
                );
    }
}