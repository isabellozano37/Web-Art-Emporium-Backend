using Data;
using Microsoft.EntityFrameworkCore;
using Web_Art_Emporium.IServicios;
using Web_Art_Emporium.Servicios;
using WebApplication1.IServices;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ISolicitudesServicio, SolicitudesServicio>();
builder.Services.AddScoped<IProductosServicio, ProductosServicio>();
builder.Services.AddScoped<IComprasServicio, ComprasServicio>();

builder.Services.AddDbContext<ServiceContext>(
        options =>
options.UseSqlServer("name=ConnectionStrings:ServiceContext"));

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
