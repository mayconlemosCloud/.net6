namespace Dominio.Interface.Generico
{
    public interface InterfaceGenericos<T> where T : class
    {
        Task<T> Adicionar(T Objeto);

        Task<T> Atualizar(T Objeto);

        Task<T> Excluir(string Id);

        Task<T> BuscarPorId(string Id);

        Task<List<T>> Listar();
    }
}