using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MiddlewareEIT.API.Authorization;
using MiddlewareEIT.API.Helpers;
using MiddlewareEIT.BL.Data;
using System;
using MiddlewareEIT.API.Services;

namespace MiddlewareEIT.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsProduction())
                services.AddDbContext<BdMiddlewareEITContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BdMiddlewareContext")));
            else
                services.AddDbContext<BdMiddlewareEITContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BdMiddlewareContext")));

            services.AddCors();
            //services.AddControllers();
            services.AddControllers(options =>
                {
                    // requires using Microsoft.AspNetCore.Mvc.Formatters;
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();
                    options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                })
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MiddlewareEIT", Version = "v1" });
                });

            // configure DI for application services
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiddlewareEIT v1"));
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiddlewareEIT v1"));
            }

            // custom jwt auth middleware
            //app.UseMiddleware<TokenValidationHandler>();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
