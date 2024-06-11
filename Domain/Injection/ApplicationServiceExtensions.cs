using EventHistory.Database;
using EventHistory.Interfaces;
using EventHistory.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;

namespace EventHistory.Domain.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.TryAddTransient<ITestService, TestService>();

            services.AddMemoryCache();

            //services.AddAutoMapper(typeof(MappingProfile).Assembly);

            var AllowedOrigins = config.GetSection("Cors:AllowedOrigins").Value.Split(",");
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(AllowedOrigins);
                });
            });

            services.AddDbContext<EventHistoryContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configSettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()

                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configSettings)
                .CreateLogger();


            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
                    config.AddJsonFile($"appsettings.{env}.json", optional: true);
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddSerilog();
                });
        }
    }
}
