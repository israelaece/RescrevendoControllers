using ANC.Web.UI.Loja.Core.Dominio;
using ANC.Web.UI.Loja.Core.Dominio.Repositorios;
using ANC.Web.UI.Loja.Core.Infraestrutura;

namespace ANC.Web.UI.Loja.Core.Comandos
{
    public class AdicionarCliente : Command
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Foto { get; internal set; }
    }

    public class AdicionarClienteHandler : IHandler<AdicionarCliente>
    {
        private readonly IRepositorioDeClientes repositorio;

        public AdicionarClienteHandler(IRepositorioDeClientes repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Handle(AdicionarCliente message)
        {
            var novoCliente = new Cliente()
            {
                Nome = message.Nome,
                Email = message.Email,
                Foto = message.Foto,
                Senha = GerarSenha()
            };

            this.repositorio.Adicionar(novoCliente);
        }

        private static string GerarSenha()
        {
            return "P@$$w0rd";
        }
    }
}