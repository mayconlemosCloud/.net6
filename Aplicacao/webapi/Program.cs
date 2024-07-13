using Aplicacao.Interfaces.Servicos;
using Aplicacao.Servicos;
using Dominio.Entidades;
using Dominio.Interface.Generico;
using Dominio.Interface.Repositorio;
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

builder.Services.AddDefaultIdentity<Usuarios>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Contexto>();

// INTERFACE E REPOSITORIO GENERICOS
builder.Services.AddScoped(typeof(InterfaceGenericos<>), typeof(RepositorioGenerico<>));

// Services
builder.Services.AddScoped<IServicosUsuarios, ServicosUsuarios>();
builder.Services.AddScoped<IServicosTeste, ServicosTeste>();

//Repositorio
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorioTeste, RepositorioTeste>();

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