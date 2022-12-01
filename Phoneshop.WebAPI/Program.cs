using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using PhoneShop.API.Helpers;

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddDbContext<DataContext>(option => builder
    .Configuration
    .GetConnectionString(System.Configuration.ConfigurationManager
    .ConnectionStrings["PhoneshopDatabase"]
    .ConnectionString),
    ServiceLifetime.Scoped);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IBrandservice, BrandService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddIdentity<IdentityUser, IdentityRole>();
builder.Services.AddLogging(x => x.AddConfiguration(builder.Configuration));
builder.InitAuth();
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