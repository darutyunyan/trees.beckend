using Microsoft.Extensions.Options;
using Trees.Api;
using Trees.Api.Mapping;
using Trees.Api.Utils;
using Trees.Core.Interfaces;
using Trees.Infrastructure.Persistance.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Configuration.
builder.Services.Configure<AppSettings>(builder.Configuration);

// Add services to the container.

// Databases.
AppSettings? settings = builder.Configuration.Get<AppSettings>();
builder.Services.ConfigureApplicationDB(settings);
builder.Services.ConfigureLogDb(settings);

// Repositories.
builder.Services.ConfigureRepositories();

// Services.
builder.Services.ConfigureServices();

// Cors.
builder.Services.ConfigureCors();

// Mappers.
builder.Services.AddAutoMapper(typeof(DbMappingProfile), typeof(ApiMappingProfile));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
