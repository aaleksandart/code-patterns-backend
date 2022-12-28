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

    //Services
    builder.Services.AddScoped<ICreateProductService, CreateProductService>();
    builder.Services.AddScoped<IGetProductsService, GetProductsService>();
    builder.Services.AddScoped<IGetProductService, GetProductService>();
    //Factories
    builder.Services.AddSingleton<IProductModelFactory, ProductModelFactory>();
    builder.Services.AddSingleton<IProductEntityFactory, ProductEntityFactory>();
    builder.Services.AddSingleton<IGenericFactory, GenericFactory>();
    //Database
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

app.UseCors(x => x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
