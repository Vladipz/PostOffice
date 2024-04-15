using lab3.Data;
using lab3.Interfaces;
using lab3.Models;
using lab3.Repositories;
using lab3.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseMongoDB(mongoDBSettings.LocalURI ?? "", mongoDBSettings.DatabaseName ?? "");


});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();


builder.Services.AddScoped<CostCalculator>();
builder.Services.AddScoped<DateCalculator>();
builder.Services.AddScoped<DistanceCalculator>();





builder.Services.AddCors(options => options
        .AddPolicy("AllowAll", builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));
var app = builder.Build();
app.UseCors("AllowAll");

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
