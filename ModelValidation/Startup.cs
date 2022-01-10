// #define DisableValidation
// #define DisableClientValidation

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ValidationSample.Data;
using ValidationSample.Services;
using ValidationSample.Validation;

namespace ValidationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options =>
                options.UseInMemoryDatabase("Movies"));

            services.AddSingleton<IUserService, UserService>();

            #region snippet_Configuration
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.MaxModelValidationErrors = 50;
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        _ => "The field is required.");
                });

            services.AddSingleton<IValidationAttributeAdapterProvider,
                CustomValidationAttributeAdapterProvider>();
            #endregion

            services.AddControllersWithViews();

#if DisableValidation
            #region snippet_DisableValidation
            services.AddSingleton<IObjectModelValidator, NullObjectModelValidator>();
            #endregion
#endif

#if DisableClientValidation
            #region snippet_DisableClientValidation
            services.AddRazorPages()
                .AddViewOptions(options =>
                {
                    options.HtmlHelperOptions.ClientValidationEnabled = false;
                });
            #endregion
#endif
#if DEBUG
            /*
             * Requires package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
             * https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-5.0&tabs=visual-studio
             */
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}