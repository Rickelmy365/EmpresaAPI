using EmpresaAPI.Domain.Interfaces;
using EmpresaAPI.Infrastructure;
using EmpresaAPI.Domain.Services;
using Microsoft.EntityFrameworkCore;
using EmpresaAPI.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with MySQL

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SGHSS - Sistema de Gestão Hospitalar e de Saúde",
        Version = "v1",
        Description = "API para gerenciamento de pacientes do sistema hospitalar SGHSS",
    });
});

builder.Services.AddScoped<IPacientesRepository, PacientesRepository>();
builder.Services.AddScoped<PacientesServices>();
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
app.UseRouting();
app.Run();
