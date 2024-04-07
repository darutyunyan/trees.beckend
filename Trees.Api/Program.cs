using Trees.Api;
using Trees.Api.Mapping;
using Trees.DataAccess.Mapping;

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
