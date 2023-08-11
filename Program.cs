using Microsoft.AspNetCore.Hosting;
using PruebaAPi.Controllers;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

UI.CadenaSQL = builder.Configuration.GetConnectionString("default");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var misReglasCors = "ReglasCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: misReglasCors,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();


                      });
});








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(misReglasCors);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("https://192.168.51.98:5001");

