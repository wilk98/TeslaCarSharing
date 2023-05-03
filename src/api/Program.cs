using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using AutoMapper;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Application.Services;
using TeslaCarSharing.Infrastructure;
using TeslaCarSharing.Infrastructure.Repositories;
using TeslaCarSharing.Application.Profiles;
using FluentValidation.AspNetCore;
using FluentValidation;
using TeslaCarSharing.Application.DTOs.Reservation;
using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Application.DTOs.Car;
using TeslaCarSharing.Application.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<TeslaCarSharingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeslaCarSharingConnectionString"));
});


builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IPricePerDayProvider, TeslaPricePerDayProvider>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddFluentValidation();
builder.Services.AddTransient<IValidator<CreateReservationDto>, CreateReservationDtoValidator>();
builder.Services.AddTransient<IValidator<CustomerDto>, CustomerDtoValidator>();
builder.Services.AddTransient<IValidator<CarDto>, CarDtoValidator>();




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TeslaCarSharing API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TeslaCarSharing API v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
