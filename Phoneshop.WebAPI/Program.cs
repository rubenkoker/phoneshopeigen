using Microsoft.EntityFrameworkCore;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Shared;
using Phoneshop.Shared.extensions;
var builder = WebApplication.CreateBuilder(args);
ILogger logger;
var services = new ServiceCollection();

builder.Services.AddControllers()
     .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(o => o.AddPolicy("myAllowSpecificOrigins", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddSwaggerGen();
ServiceProvider serviceProvider = services.BuildServiceProvider();
builder.Services.AddDbContext<DataContext>(option => builder
    .Configuration
    .GetConnectionString(System.Configuration.ConfigurationManager
    .ConnectionStrings["PhoneshopDatabase"]
    .ConnectionString),
    ServiceLifetime.Scoped);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

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