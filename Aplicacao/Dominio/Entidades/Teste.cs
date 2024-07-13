using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Teste
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = String.Empty;

        public TipoUsuario Tipo { get; set; } = TipoUsuario.admin;

    }
}
