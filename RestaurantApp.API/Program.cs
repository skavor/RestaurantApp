using Microsoft.EntityFrameworkCore;
using RestaurantApp.API.Data.DataAccess;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Services;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("RestaurantContext"));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//Add services
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMealService, MealService>();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
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
