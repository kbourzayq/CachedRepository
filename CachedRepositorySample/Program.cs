using CachedRepositorySample.Data;
using CachedRepositorySample.Data.Contracts;
using CachedRepositorySample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=ConnectionStrings:Default"));
//builder.Services.AddScoped<IReadOnlyRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IReadOnlyRepository<Customer>, CachedCustomerRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
