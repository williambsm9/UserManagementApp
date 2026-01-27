using Infrastructure.Persistence;
using Application.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using System.Net;
using System.Text.Json;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Services;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// SQLite in-memory connection (must stay open)
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connection));

// DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();



builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Create DB schema
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseExceptionHandler(errorApp =>
{
errorApp.Run(async context =>
{
var exception = context.Features
.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()
?.Error;


context.Response.ContentType = "application/json";


switch (exception)
{
case NotFoundException:
context.Response.StatusCode = StatusCodes.Status404NotFound;
break;


case ValidationException:
context.Response.StatusCode = StatusCodes.Status400BadRequest;
break;


default:
context.Response.StatusCode = StatusCodes.Status500InternalServerError;
break;
}
});
});

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

public partial class Program { }