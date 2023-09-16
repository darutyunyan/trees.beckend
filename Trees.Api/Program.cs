using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Trees.Api;
using Trees.Api.Mapping;
using Trees.Core.Interfaces;
using Trees.Core.Services;
using Trees.Infrastructure.Persistance.Context;
using Trees.Infrastructure.Persistance.Mapping;
using Trees.Infrastructure.Persistance.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configuration.
builder.Services.Configure<AppSettings>(builder.Configuration);

// Add services to the container.

// Databases.
AppSettings? settings = builder.Configuration.Get<AppSettings>();

builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
    options.UseSqlServer(
        string.Format(
            AppSettings.DB_CONNECTION_FORMAT,
            settings.DBAppSettings.DataSource,
            settings.DBAppSettings.DataBase,
            settings.DBAppSettings.UserID,
            settings.DBAppSettings.Password)));


builder.Services.AddDbContext<ILogDbContext, LogDbContext>(options =>
    options.UseSqlServer(
        string.Format(
            AppSettings.DB_CONNECTION_FORMAT,
            settings.DBLogSettings.DataSource,
            settings.DBLogSettings.DataBase,
            settings.DBLogSettings.UserID,
            settings.DBLogSettings.Password)));

// Repositories.
builder.Services.AddScoped<ITreeRepository, TreeRepository>();
builder.Services.AddScoped<IAssemblyMethodRepository, AssemblyMethodRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IImgRepository, ImgRepository>();
builder.Services.AddScoped<ILegRepository, LegRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

// Services.
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<IAssemblyMethodService, AssemblyMethodService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IImgService, ImgService>();
builder.Services.AddScoped<ILegService, LegService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ILocationService, LocationService>();

// Mappers.
builder.Services.AddAutoMapper(typeof(DbMappingProfile), typeof(ApiMappingProfile));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Map("/", async (
    IOptions<AppSettings> options,
    IBrandService service,
    ITreeService s,
    ILocationService r,
    IMaterialService m,
    IReviewService we,
    IAssemblyMethodService ase,
    IImgService imgs,
    ILegService legs) =>
{
    AppSettings person = options.Value;  // получаем переданные через Options объект Person

    try
    {
        var res1 = await service.GetAllAsync();
        var res2 = await s.GetAllAsync();
        var res3 = await r.GetAsync();
        var res4 = await m.GetAllAsync();
     
        var res6 = await ase.GetAllAsync();
        var res7 = await imgs.GetAllAsync();
        var res8 = await legs.GetAllAsync();
        var res5 = await we.GetAllAsync();
    }
    catch (Exception ex)
    {
        var weew = ex;

    }



    return person;
});

app.Run();
