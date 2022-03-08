using AutomobileAPI.Business;
using AutomobileAPI.BusinessLayer;
using AutomobileAPI.DataLayer;
using AutomobileAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AutomobileDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutomobileDB"));
});
builder.Services.AddScoped<IProcessCarMake, ProcessCarMake>();
builder.Services.AddScoped<ICarMakeDAL, CarMakeDAL>();
builder.Services.AddScoped<IProcessCarModel, ProcessCarModel>();
builder.Services.AddScoped<ICarModelDAL, CarModelDAL>();
builder.Services.AddScoped<IProcessCarForSale, ProcessCarForSale>();
builder.Services.AddScoped<ICarForSaleDAL, CarForSaleDAL>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items, Ver new"
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
    builder =>
    {
        builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAll");
app.Run();
