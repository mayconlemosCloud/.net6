using Dominio.Interfaces.Genericos;
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Generico
{
    public class RepositorioGenerico<T> : InterfaceGenericos<T> where T : class
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;

        public RepositorioGenerico(DbContextOptions<Contexto> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task Adicionar(T Objeto)
        {
            using(var data = new Contexto(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscarPorId(string Id)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task Excluir(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> Listar()
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }

        }
    }
}
