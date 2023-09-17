using Microsoft.EntityFrameworkCore;
using Trees.Api.Services.Mail;
using Trees.Core.Interfaces;
using Trees.Core.Services;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Repository;

namespace Trees.Api.Utils
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureApplicationDB(this IServiceCollection services, AppSettings? settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(string.Format(
                    AppSettings.DB_CONNECTION_FORMAT,
                    settings.DBAppSettings.DataSource,
                    settings.DBAppSettings.DataBase,
                    settings.DBAppSettings.UserID,
                    settings.DBAppSettings.Password)));
        }

        public static void ConfigureLogDb(this IServiceCollection services, AppSettings? settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            services.AddDbContext<ILogDbContext, LogDbContext>(options =>
                options.UseSqlServer(
                    string.Format(
                        AppSettings.DB_CONNECTION_FORMAT,
                        settings.DBLogSettings.DataSource,
                        settings.DBLogSettings.DataBase,
                        settings.DBLogSettings.UserID,
                        settings.DBLogSettings.Password)));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<IAssemblyMethodRepository, AssemblyMethodRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IImgRepository, ImgRepository>();
            services.AddScoped<ILegRepository, LegRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ITreeService, TreeService>();
            services.AddScoped<IAssemblyMethodService, AssemblyMethodService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IImgService, ImgService>();
            services.AddScoped<ILegService, LegService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddSingleton<IMailService, MailService>();
        }
    }
}
