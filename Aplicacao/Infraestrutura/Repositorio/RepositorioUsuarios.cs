using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuarios : RepositorioGenerico<Usuarios>, InterfaceUsuarios
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;

        public RepositorioUsuarios(DbContextOptions<Contexto> optionsBuilder) : base(optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }
    }
}
