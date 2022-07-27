using FluentValidation;
using FluentValidation.AspNetCore;
using GamerLibrary.Common.Core.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamerLibrary.Common.Core.API
{
    /// <summary>
    /// To be inherit in the StartUp class for set-up all the common configuration and dependencies in the API service
    /// </summary>
    public abstract class BaseStartUp
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private List<Type> AssemblyTypes { get; }

        public BaseStartUp(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            AssemblyTypes = new();
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// To be overriten for any API Service that inherit from this base class
        /// E.g: For dependency injection for any project
        /// </summary>
        /// <param name="services"></param>
        public abstract void ConfigureDepencencies(IServiceCollection services);

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(config =>
                {
                    foreach (var type in AssemblyTypes)
                    {
                        config.RegisterValidatorsFromAssemblyContaining(type);
                    }
                })
                .AddJsonOptions(opt => opt.JsonSerializerOptions.SetSerializeOptions());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            AddValidatorDependencies(services);

            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }

        /// <summary>
        /// Adds all validators in the assembly of the specified type
        /// </summary>
        /// <param name="services"></param>
        private void AddValidatorDependencies(IServiceCollection services)
        {
            foreach (var type in AssemblyTypes)
            {
                services.AddValidatorsFromAssemblyContaining(type);
            }
        }
    }
}
