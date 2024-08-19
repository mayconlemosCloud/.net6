using Dominio.Interface.Generico;
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio.Generico
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;

        public RepositorioGenerico(DbContextOptions<Contexto> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task<T> Adicionar(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                var t = await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
                return t.Entity;
            }
        }

        public async Task<T> Atualizar(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
                return Objeto;
            }
        }

        public async Task<T> BuscarPorId(string Id)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<T> Excluir(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                var t = data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
                return t.Entity;
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