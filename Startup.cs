using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Filters;
using App.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<HotelInfo>(
            Configuration.GetSection("Info"));
            services
            .AddMvc(options=> {
                options.Filters.Add<JsonExceptionFilter>();
                options.Filters.Add<RequireHttpsOrCloseAttribute>();
                })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRouting(options=> options.LowercaseUrls= true);
            // Register the Swagger services
            services.AddSwaggerDocument();
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader =
                new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector =
                new CurrentImplementationApiVersionSelector(options);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyApp",
                    policy => policy.AllowAnyOrigin());
            });

            services.AddDbContext<HotelApiDbContext>(
            options => options.UseInMemoryDatabase("landondb")
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Register the Swagger generator and the Swagger UI middlewares
                app.UseSwagger();
                app.UseSwaggerUi3();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowMyApp");
            app.UseMvc();
            
        }
    }
}
