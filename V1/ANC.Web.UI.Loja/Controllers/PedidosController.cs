using ANC.Web.UI.Loja.Infraestrutura;
using ANC.Web.UI.Loja.Models;
using ANC.Web.UI.Loja.Repositorios;
using System;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly IRepositorioDeClientes repositorioDeClientes;
        private readonly IRepositorioDePedidos repositorioDePedidos;
        private readonly IRepositorioDeProdutos repositorioDeProdutos;
        private readonly INotificador notificador;

        public PedidosController()
        {
            this.repositorioDeClientes = new RepositorioDeClientes();
            this.repositorioDePedidos = new RepositorioDePedidos();
            this.repositorioDeProdutos = new RepositorioDeProdutos();
            this.notificador = new NotificadorViaEmail();
        }

        public ActionResult Index()
        {
            var cliente = this.repositorioDeClientes.BuscarPor(this.ClienteId);

            return View(repositorioDePedidos.BuscarPor(cliente));
        }

        public ActionResult Comprar(Guid id)
        {
            var cliente = this.repositorioDeClientes.BuscarPor(this.ClienteId);
            var produto = this.repositorioDeProdutos.BuscarPor(id);
            var quantidade = 1;

            var novoPedido = new Pedido(cliente);
            novoPedido.AdicionarItem(new Item(produto, quantidade));

            this.repositorioDePedidos.Adicionar(novoPedido);

            this.notificador.Send(
                "sistema@loja.com.br", cliente.Email, "Novo Pedido", GerarMensagem(novoPedido));

            return RedirectToAction("Index");
        }

        private static string GerarMensagem(Pedido pedido)
        {
            return
                string.Format(
                    "O seu pedido de número <b>{0}</b> no total de <b>{1:N2}</b> foi criado com sucesso em nossa base de dados, e aguarda a aprovação da operadora de cartão de crédito.",
                    pedido.Id.ToString().ToUpper(),
                    pedido.Total);
        }
    }
}