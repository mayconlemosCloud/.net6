using Dominio.Interfaces;
using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<Contexto>(opcoes => opcoes.UseNpgsql(
    builder.Configuration.GetConnectionString("PGDB")));



// INTERFACE E REPOSITORIO

builder.Services.AddScoped(typeof(InterfaceGenericos<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<InterfaceUsuarios, RepositorioUsuarios>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
