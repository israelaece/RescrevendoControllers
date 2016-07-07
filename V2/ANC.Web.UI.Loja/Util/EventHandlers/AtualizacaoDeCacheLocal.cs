using ANC.Web.UI.Loja.Core.Eventos;
using ANC.Web.UI.Loja.Core.Infraestrutura;
using ANC.Web.UI.Loja.Models;

namespace ANC.Web.UI.Loja.Util.EventHandlers
{
    public class AtualizacaoDeCacheLocal : IHandler<ClienteAdicionado>, IHandler<PedidoAdicionado>
    {
        private readonly IDados dados;

        public AtualizacaoDeCacheLocal(IDados dados)
        {
            this.dados = dados;
        }

        public void Handle(ClienteAdicionado message)
        {
            dados.Adicionar(new PosicaoDoCliente()
            {
                Id = message.Id,
                Email = message.Email,
                Foto = message.Foto,
                Nome = message.Nome
            });
        }

        public void Handle(PedidoAdicionado message)
        {
            AtualizarPosicaoDoCliente(message);
            AdicionarPedidoRealizado(message);
            AtualizarEstoqueDaVitrine(message);
        }

        private void AtualizarPosicaoDoCliente(PedidoAdicionado @event)
        {
            var posicao = dados.RecuperarPosicaoDoCliente(@event.ClienteId);

            posicao.QuantidadeDePedidos++;
            posicao.TotalDosPedidos += @event.Total;
            posicao.DataDoUltimoPedido = @event.Data;
        }

        private void AdicionarPedidoRealizado(PedidoAdicionado @event)
        {
            this.dados.Adicionar(new PedidoRealizado()
            {
                ClienteId = @event.ClienteId,
                Data = @event.Data,
                PedidoId = @event.PedidoId,
                Total = @event.Total,
                NomeDaTransportadora = @event.Transportadora
            });
        }

        private void AtualizarEstoqueDaVitrine(PedidoAdicionado @event)
        {
            foreach (var item in @event.ProdutosComprados)
            {
                var produto = dados.RecuperarProdutoPor(item.Key);

                if (produto != null)
                    produto.QuantidadeEmEstoque -= item.Value;
            }
        }
    }
}