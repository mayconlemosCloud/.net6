using Aplicacao.Interfaces.Servicos;
using Aplicacao.Servicos;
using Aplicacao.Token;
using Dominio.Entidades;
using Dominio.Interface.Generico;
using Dominio.Interface.Repositorio;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Generico;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configurar Swagger para JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    // Adicionar configuração de segurança para JWT Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer.\r\n\r\n" +
                      "Entre com o token no campo de texto abaixo.\r\n\r\n" +
                      "Exemplo: \"{seu token}\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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
builder.Services.AddScoped<IRepositorioTeste, RepositorioTeste>();

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "Teste.Securiry.Bearer",
              ValidAudience = "Teste.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-1223w23231231231ewe345dsadasda422@$678")
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();


// Apply migrations and seed the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Contexto>();
    db.Database.Migrate(); // Apply any pending migrations
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();