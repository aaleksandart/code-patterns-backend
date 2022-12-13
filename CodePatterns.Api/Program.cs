using CodePatterns.Data;
using CodePatterns.Data.Context;
using CodePatterns.Data.Factories;
using CodePatterns.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data layer
builder.Services.AddScoped<IDataLayer, DataLayer>();
builder.Services.AddScoped<ICreateEntities, CreateEntities>();
builder.Services.AddScoped<ICreateModels, CreateModels>();
builder.Services.AddSingleton<IProductFactory, ProductFactory>();
builder.Services.AddDbContext<SqlContext>(
    x => x.UseSqlServer(config["DatabaseSettings:ConnectionString"]));

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
