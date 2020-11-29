using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using AdventureWorks.Data;
using System;
using System.Reflection;
using System.Linq;
using AdventureWorksWebDemo.Core;
using AdventureWorksWebDemo.Models;
using AdventureWorksWebDemo.Repositories;
using AdventureWorksWebDemo.Models.HumanResources;
using AdventureWorksWebDemo.Generators;
using AdventureWorksWebDemo.Models.Production;

namespace AdventureWorksWebDemo
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var cors = Configuration.GetValue<string>("cors").Split(',', StringSplitOptions.RemoveEmptyEntries);
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(cors);
                                  });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<AdventureWorks2016Context>();

            this.RegisterRepositories(services);

            services.AddSingleton<IMetadataGenerator, MetadataGenerator>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<DepartmentModel>), typeof(DepartmentRepository));
            services.AddScoped(typeof(IRepository<EmployeeModel>), typeof(EmployeeRepository));
            services.AddScoped(typeof(IRepository<JobCandidateModel>), typeof(JobCandidateRepository));
            services.AddScoped(typeof(IRepository<ShiftModel>), typeof(ShiftRepository));
            services.AddScoped(typeof(IRepository<ProductModel>), typeof(ProductRepository));
        }
    }
}
