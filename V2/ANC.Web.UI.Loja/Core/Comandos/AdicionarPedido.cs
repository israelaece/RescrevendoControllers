using ANC.Web.UI.Loja.Core.Dominio;
using ANC.Web.UI.Loja.Core.Dominio.Repositorios;
using ANC.Web.UI.Loja.Core.Infraestrutura;
using System;

namespace ANC.Web.UI.Loja.Core.Comandos
{
    public class AdicionarPedido : Command
    {
        public Guid ClienteId { get; set; }

        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }
    }

    public class AdicionarPedidoHandler : IHandler<AdicionarPedido>
    {
        private readonly IRepositorioDeClientes repositorioDeClientes;
        private readonly IRepositorioDePedidos repositorioDePedidos;
        private readonly IRepositorioDeProdutos repositorioDeProdutos;

        public AdicionarPedidoHandler(
            IRepositorioDeClientes repositorioDeClientes, 
            IRepositorioDePedidos repositorioDePedidos, 
            IRepositorioDeProdutos repositorioDeProdutos)
        {
            this.repositorioDeClientes = repositorioDeClientes;
            this.repositorioDePedidos = repositorioDePedidos;
            this.repositorioDeProdutos = repositorioDeProdutos;
        }

        public void Handle(AdicionarPedido message)
        {
            var cliente = this.repositorioDeClientes.BuscarPor(message.ClienteId);
            var produto = this.repositorioDeProdutos.BuscarPor(message.ProdutoId);

            var novoPedido = new Pedido(cliente);
            novoPedido.AdicionarItem(new Item(produto, message.Quantidade));

            this.repositorioDePedidos.Adicionar(novoPedido);
        }
    }
}