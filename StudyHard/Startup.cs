using System;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudyHard.Data;
using StudyHard.Data.Repository;
using StudyHard.Dto.Configurations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StudyHard.Dto.Config;
using StudyHard.Web.Validators;
using System.Linq;
using StudyHard.ContentManagement.Services;
using StudyHard.Services;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using StudyHard.Web.Extensions;

namespace StudyHard.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_itlegorigin";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped(c => new StudyHardRepository(connection));
            services.AddDbContext<StudyHardApplicationContext>(options => options.UseSqlServer(connection));
            services.Configure<AnalyticsConfiguration>(Configuration.GetSection("Analytics"));
            services.AddSingleton(typeof(JwtConfig));
            ConfigureJwtBearer(services);
            DependencyInjection(services);
            ConfigureSwagger(services);

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApplications/Client/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudyHard");
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.ConfigureExceptionHandler(env);
                var cors = Configuration.GetSection("AllowedOrigins").AsEnumerable().ToList().Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => x.Value).ToArray();
                app.UseCors(
                    options => options.WithOrigins(cors)
                        .AllowAnyMethod()
                        .WithHeaders("Api-Key")
                );
            }
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApplications/Client";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "ng serve");
                }
            });
        }

        private void DependencyInjection(IServiceCollection services)
        {
            services.AddSingleton(x => new BlobServiceClient(Configuration.GetConnectionString("AzureBlobStorageConnectionString")));
            services.AddContentManagementServices();
            services.AddClientServices();    
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Api-Key", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Api-Key"
                });
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    In = ParameterLocation.Header, 
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey 
                });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { 
                        new OpenApiSecurityScheme 
                        { 
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" 
                            } 
                        },
                        new string[] { } 
                    } 
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference 
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Api-Key" ,
                            }
                        }, 
                        new List<string>() }
                });
            });
        }

        private void ConfigureJwtBearer(IServiceCollection services)
        {
            services.AddScoped<UserJwtValidator>();
            
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtConfig.Issuer,
                        ValidateAudience = true,
                        ValidAudience = JwtConfig.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(JwtConfig.GetSymmetricKey()),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    options.EventsType = typeof(UserJwtValidator);
                });
        }
    }
}
