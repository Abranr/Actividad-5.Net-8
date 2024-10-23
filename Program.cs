using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Conexiones>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("conexiones") ?? throw new InvalidOperationException("Connection string 'conexiones' not found.")));

 //options.UseSqlServer(builder.Configuration.GetConnectionString("conexiones") ?? throw new InvalidOperationException("Connection string 'conexiones' not found."))); // Esto es para sql server

// Add services to the container.
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ??"otracadena";
builder.Services.AddControllers();
builder.Services.AddDbContext<Conexiones>(opt =>
      opt.UseMySQL(cadena));

      // opt.UseSQL(cadena)); // Esto es para sql server

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
