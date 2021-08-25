using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Middlewares;
using CompanyTrainingManagerApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi
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

            services.AddControllers();

            //register swagger generator
            services.AddSwaggerGen();

            //making db connection
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //seeding empty database
            services.AddScoped<AppDataSeeder>();

            //using middlewares
            services.AddScoped<ExceptionHandlingMiddleware>();

            //using automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //CRUD services to controllers
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<ITrainingDefinitionService, TrainingDefinitionService>();
            services.AddScoped<ITrainingService, TrainingService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDataSeeder seeder)
        {
            seeder.Seed();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
           });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
