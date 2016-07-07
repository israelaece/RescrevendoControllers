using ANC.Web.UI.Loja.Core.Dominio;
using ANC.Web.UI.Loja.Core.Dominio.Repositorios;
using ANC.Web.UI.Loja.Core.Eventos;
using ANC.Web.UI.Loja.Core.Infraestrutura;

namespace ANC.Web.UI.Loja.Core.Repositorios
{
    public class RepositorioDeClientes : RepositorioEmMemoria<Cliente>, IRepositorioDeClientes
    {
        private readonly IBus bus;

        public RepositorioDeClientes(IBus bus)
        {
            this.bus = bus;
        }

        public override void Adicionar(Cliente entity)
        {
            base.Adicionar(entity);

            this.bus.Dispatch(new ClienteAdicionado(entity.Id, entity.Nome, entity.Email, entity.Foto, entity.Senha));
        }
    }
}