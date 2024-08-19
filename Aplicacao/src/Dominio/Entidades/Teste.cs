using Dominio.Enums;

namespace Dominio.Entidades
{
    public class Teste
    {
        public string Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public TipoUsuario Tipo { get; set; } = TipoUsuario.admin;
    }
}