using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NeedleBuddy.API.AuthService;
using NeedleBuddy.API.MessageService;
using NeedleBuddy.DB;
using Swashbuckle.AspNetCore.Swagger;

namespace NeedleBuddy.API
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
            string signingKey = Configuration.GetValue<string>("SigningKey");
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddScoped<IRepository, Repository>(r => Repository.CreateRepository(Configuration.GetConnectionString("NeedleBuddyDatabase")));
            services.AddScoped<IUserService, UserService>(us => new UserService(us.GetRequiredService<IRepository>()));
            services.AddScoped<ISMSService, SMSService>(ss => new SMSService(Configuration.GetValue<string>("SwiftBaseUrl"), ss.GetRequiredService<IRepository>()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NeedleBuddy API", Version = "v1" });
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200/",
                                        "https://localhost:4200/",
                                        "https://hackreginahackathon2019.firebaseapp.com");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NeedleBuddy API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("AllowLocalhost");
        }
    }
}
