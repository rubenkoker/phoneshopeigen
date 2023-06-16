using Microsoft.EntityFrameworkCore;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using Phoneshop.Shared;
using Phoneshop.Shared.extensions;
using PhoneShop.API.Helpers;
using PhoneShop.Business.Managers;
using PhoneShop.Contracts.Interfaces;

var builder = WebApplication.CreateBuilder(args);
ILogger logger;
var services = new ServiceCollection();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddControllers()
     .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(o => o.AddPolicy("myAllowSpecificOrigins", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.InitAuth();

builder.Services.AddScoped<ICaching<Brand>, SimpleMemoryCache<Brand>>();
builder.Services.AddScoped<IJwtAuthManager, JwtAuthManager>();
builder.Services.AddScoped<IBrandservice, BrandService>();
builder.Services.AddScoped<IRepository<Phone>, Repository<Phone>>();
builder.Services.AddScoped<IRepository<Brand>, Repository<Brand>>();
builder.Services.AddScoped<IPhoneService, PhoneService>();

//ServiceProvider serviceProvider = services.BuildServiceProvider();
builder.Services.AddDbContext<DataContext>(option => builder
    .Configuration
    .GetConnectionString(System.Configuration.ConfigurationManager
    .ConnectionStrings["PhoneshopDatabase"]
    .ConnectionString),
    ServiceLifetime.Scoped);

builder.Services.AddRouting(options => options.LowercaseUrls = true); builder.Services.AddSwaggerGen();
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