﻿using Dominio.Entidades;
using Dominio.Interface.Repositorio;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuarios : RepositorioGenerico<Usuarios>, IRepositorioUsuarios
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;

        public RepositorioUsuarios(DbContextOptions<Contexto> optionsBuilder) : base(optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }
    }
}