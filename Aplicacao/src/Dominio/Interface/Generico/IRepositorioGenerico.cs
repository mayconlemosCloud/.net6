namespace Dominio.Interface.Generico
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<T> Adicionar(T Objeto);

        Task<T> Atualizar(T Objeto);

        Task<T> Excluir(T Objeto);

        Task<T> BuscarPorId(string Id);

        Task<List<T>> Listar();
    }
}