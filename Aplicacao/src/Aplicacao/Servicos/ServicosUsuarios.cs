using Aplicacao.DTO.Request;
using Aplicacao.Interfaces.Servicos;
using Aplicacao.Token;
using Dominio.Entidades;
using Microsoft.AspNetCore.Identity;

namespace Aplicacao.Servicos
{
    public class ServicosUsuarios : IServicosUsuarios
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly SignInManager<Usuarios> _signInManager;

        public ServicosUsuarios(UserManager<Usuarios> userManager, SignInManager<Usuarios> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Login(UsuariosRequest login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.PasswordHash))
            {
                return String.Empty;
            }

            var resultado = await
                _signInManager.PasswordSignInAsync(login.Email, login.PasswordHash, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                // Recupera Usuário Logado
                var userCurrent = await _userManager.FindByEmailAsync(login.Email);
                var idUsuario = userCurrent.Id;

                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-1223w23231231231ewe345dsadasda422@$678"))
                .AddSubject("Empresa - Canal Dev Net Core")
                .AddIssuer("Teste.Securiry.Bearer")
                .AddAudience("Teste.Securiry.Bearer")
                .AddClaim("idUsuario", idUsuario)
                .AddExpiry(5)
                .Builder();

                return token.value;
            }
            else
            {
                return String.Empty;
            }
        }

        public async Task<Usuarios> Adicionar(Usuarios Objeto)
        {
            if (string.IsNullOrWhiteSpace(Objeto.Email) || string.IsNullOrWhiteSpace(Objeto.PasswordHash))
            {
                return await Task.FromResult(Objeto);
            }

            var user = new Usuarios
            {
                Email = Objeto.Email,
                UserName = Objeto.Email,
                EmailConfirmed = true
            };

            var resultado = await _userManager.CreateAsync(user, Objeto.PasswordHash);

            if (resultado.Succeeded)
            {
                return user;
            }

            return await Task.FromResult(new Usuarios());
        }

        public Task<Usuarios> Atualizar(Usuarios Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Usuarios> BuscarPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuarios> Excluir(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuarios>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}