using ANC.Web.UI.Loja.Core.Dominio;
using ANC.Web.UI.Loja.Core.Dominio.Repositorios;
using ANC.Web.UI.Loja.Core.Eventos;
using ANC.Web.UI.Loja.Core.Infraestrutura;
using System.Linq;

namespace ANC.Web.UI.Loja.Core.Repositorios
{
    public class RepositorioDePedidos : RepositorioEmMemoria<Pedido>, IRepositorioDePedidos
    {
        private readonly IBus bus;

        public RepositorioDePedidos(IBus bus)
        {
            this.bus = bus;
        }

        public override void Adicionar(Pedido entity)
        {
            base.Adicionar(entity);

            this.bus.Dispatch(GerarPedidoAdicionado(entity));
        }

        private PedidoAdicionado GerarPedidoAdicionado(Pedido entity)
        {
            return new PedidoAdicionado()
            {
                ClienteId = entity.Cliente.Id,
                PedidoId = entity.Id,
                Data = entity.Data,
                EmailDoCliente = entity.Cliente.Email,
                Total = entity.Total,
                Transportadora = entity.Transportadora.Nome,
                ProdutosComprados = entity.Itens.ToDictionary(i => i.Produto.Id, i => i.Quantidade)
            };
        }
    }
}