using Trees.Api;
using Trees.Api.Mapping;
using Trees.Infrastructure.Persistence.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Configuration.
string settingsFilePath = string.Format(AppSettings.AppSettingsFileFormat, builder.Environment.EnvironmentName);
builder.Configuration.AddJsonFile(settingsFilePath);
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
builder.Services.AddAutoMapper(typeof(ApiMappingProfile), typeof(DbMappingProfile));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
