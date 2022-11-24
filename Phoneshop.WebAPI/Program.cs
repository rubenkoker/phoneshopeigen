using Microsoft.EntityFrameworkCore;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Shared;
using Phoneshop.Shared.extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option => builder
.Configuration
.GetConnectionString("DefaultConnection"),
ServiceLifetime.Scoped);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddLogging(x => x.AddConfiguration(builder.Configuration));

ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();

ServiceCollection phoneservices = new();

serviceProvider = phoneservices.BuildServiceProvider();
//brandservice = serviceProvider.GetRequiredService<IBrandservice>();
// _logger = serviceProvider.GetRequiredService<ILogger>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
builder.Services.AddDbContext<DataContext>(
             options => options.UseSqlServer(_connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
static void ConfigureServices(ServiceCollection services)
{
    services.AddScoped<IPhoneService, PhoneService>();
    services.AddScoped<IBrandservice, BrandService>();
    services.AddScoped<ILogger, CustomLogger>();
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

    services.AddLogging(config => config.AddColorConsoleLogger(config =>
    {
        config.LogLevelToColorMap[LogLevel.Information] = ConsoleColor.Cyan;
        config.LogLevelToColorMap[LogLevel.Warning] = ConsoleColor.Yellow;
        config.LogLevelToColorMap[LogLevel.Error] = ConsoleColor.Red;
        config.LogLevelToColorMap[LogLevel.Critical] = ConsoleColor.DarkRed;
        config.LogLevelToColorMap[LogLevel.Debug] = ConsoleColor.Blue;
    }));

    string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
    services.AddDbContext<DataContext>(
                 options => options.UseSqlServer(_connectionString));
}