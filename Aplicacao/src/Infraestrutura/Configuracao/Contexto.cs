using Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracao
{
    public class Contexto : IdentityDbContext<Usuarios>
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Teste> Testes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //table Teste
            builder.Entity<Teste>().ToTable("Teste").HasKey(t => t.Id);
            builder.Entity<Teste>().Property(t => t.Id)
            .ValueGeneratedOnAdd();

            //Usuario
            builder.Entity<Usuarios>().ToTable("AspNetUsers").HasKey(t => t.Id);
          
            base.OnModelCreating(builder);
        }
    }
}