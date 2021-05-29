using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Contexts;
using DataLayer.Repositories.Operations;
using DataLayer.Repositories.Targets;
using Microsoft.EntityFrameworkCore;
using DataLayer.Repositories.DetectedObjects;
using DataLayer.Repositories.Images;
using DataLayer.Repositories.Missions;
using Microsoft.AspNetCore.Identity;
using DataLayer.Models;
using DataLayer.Repositories.Users;

namespace ObjectSearchAPI
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
            services.AddCors();

            services.AddDbContext<ObjectSearchContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<ObjectSearchContext>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ObjectSearchAPI", Version = "v1" });
            });

            services.AddScoped<IDetectedObjectRepository, DetectedObjectRepository>();
            services.AddScoped<IOperationsRepository, OperationsRepository>();
            services.AddScoped<ITargetRepository, TargetRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IMissionRepository, MissionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed((host) => true)
                            .AllowCredentials()
                        );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ObjectSearchAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
