using ANC.Web.UI.Loja.Core.Infraestrutura;
using System;

namespace ANC.Web.UI.Loja.Core.Eventos
{
    public class ClienteAdicionado : Event
    {
        public ClienteAdicionado(Guid id, string nome, string email, string foto, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Foto = foto;
            this.Senha = senha;
        }

        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Foto { get; private set; }

        public string Senha { get; private set; }
    }
}