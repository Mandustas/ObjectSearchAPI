using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ObjectSearchAPI.Services;
using ObjectSearchAPI.Hubs;

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
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions.AuthOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,

                        ValidateLifetime = true,
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(), //HS256

                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddDbContext<ObjectSearchContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<ObjectSearchContext>();
            services.AddSignalR();
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
            services.AddScoped<IClusteringService, ClusteringService>();
            services.AddScoped<INotificationService, NotificationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                            .WithOrigins("http://waiting-lock.surge.sh/")
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

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("api/notification");
            });
        }
    }
}
