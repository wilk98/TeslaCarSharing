using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Application.Services;
using TeslaCarSharing.Infrastructure;
using TeslaCarSharing.Infrastructure.Repositories;
using TeslaCarSharing.Application.Profiles;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TeslaCarSharingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeslaCarSharingConnectionString"));
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();