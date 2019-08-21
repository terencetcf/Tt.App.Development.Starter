using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tt.App.WebApi.Infrastructure.DependencyInjection;
using Tt.App.WebApi.Infrastructure.Middleware;
using Tt.App.Data.EfCore;
using Tt.App.Services;
using Microsoft.AspNetCore.Mvc.Versioning;
using Tt.App.WebApi.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using System;

namespace Tt.App.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddConfigurationDescriptors(Configuration)
                .AddRepositoryDescriptors()
                .AddMapperDescriptors()
                .AddServiceDescriptors();

            services.AddAutoMapper(typeof(Startup), typeof(TimeService));

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));

            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(2, 0);
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                //// In case to implements versioning in Header or QueryString
                //// opt.ApiVersionReader = ApiVersionReader.Combine(
                ////     new HeaderApiVersionReader("X-Version"),
                ////     new QueryStringApiVersionReader("ver", "version"));
            });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v2", new Info
                {
                    Version = "v2",
                    Title = "Tt.App Web API",
                    Description = "Tt.App.WebApi",
                    Contact = new Contact
                    {
                        Name = "Terence Tai",
                        Url = "https://github.com/terencetcf",
                    },
                    License = new License
                    {
                        Name = "The MIT License (MIT)",
                        Url = "https://opensource.org/licenses/MIT",
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var swaggerConfig = new SwaggerConfiguration();
            Configuration.GetSection(nameof(SwaggerConfiguration)).Bind(swaggerConfig);

            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerConfig.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerConfig.UiEndpoint, swaggerConfig.Description);
            });

            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseLastRequestTracking();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
