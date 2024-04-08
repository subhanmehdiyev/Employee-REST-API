using Microsoft.EntityFrameworkCore;
using EmployeeRestAPI.Data;
using EmployeeRestAPI.Repository;
using EmployeeRestAPI.UnitOfWork;
using System.Reflection;
using EmployeeRestAPI.Maps;
using System.ComponentModel.DataAnnotations;
using EmployeeRestAPI.Models;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddScoped<IValidator<EmployeeModel>,EmployeeModelValidator>();
builder.Services.AddScoped<IValidator<EmployeeForUpdatingModel>, EmployeeForUpdatingModelValidator>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
