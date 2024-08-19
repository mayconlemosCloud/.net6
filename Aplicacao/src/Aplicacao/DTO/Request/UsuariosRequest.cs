namespace Aplicacao.DTO.Request
{
    public class UsuariosRequest
    {
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
    }
}