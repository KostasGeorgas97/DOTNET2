global using DOTNET2.Models;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.HttpsPolicy;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using System.Text.Json.Serialization;
global using System.Net.Http;
global using Uni.Controllers;
global using DOTNET2.Services.UniversitiesService;
global using DOTNET2.Data;
global using Microsoft.EntityFrameworkCore;
global using context = DOTNET2.Data.DataContext;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUniversitiesService, UniversitiesService>(); // Dependency injection// Add services to the container

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
context.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
