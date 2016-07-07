using ANC.Web.UI.Loja.Core.Comandos;
using ANC.Web.UI.Loja.Util;
using System;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly IDados dados;

        public PedidosController(IDados dados)
        {
            this.dados = dados;
        }

        public ActionResult Index()
        {
            return View(dados.RecuperarPedidosRelizadosPor(this.ClienteId));
        }

        public ActionResult Comprar(Guid id)
        {
            return this.Command(
                new AdicionarPedido()
                {
                    ClienteId = this.ClienteId,
                    ProdutoId = id,
                    Quantidade = 1
                },
                RedirectToAction("Index"));
        }
    }
}