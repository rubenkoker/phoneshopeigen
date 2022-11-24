using Microsoft.EntityFrameworkCore;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option => builder
.Configuration
.GetConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString),
ServiceLifetime.Scoped);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IBrandservice, BrandService>();
builder.Services.AddScoped(typeof(IRepository<Phone>), typeof(Repository<Phone>));
builder.Services.AddScoped(typeof(IRepository<Brand>), typeof(Repository<Brand>));

builder.Services.AddLogging(x => x.AddConfiguration(builder.Configuration));

string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PhoneshopDatabase"].ConnectionString;
builder.Services.AddDbContext<DataContext>(
             options => options.UseSqlServer(_connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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