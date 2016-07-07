using ANC.Web.UI.Loja.Repositorios;
using System;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Controllers
{
    public class CatalogoController : BaseController
    {
        private readonly IRepositorioDeProdutos repositorioDeProdutos;

        public CatalogoController()
        {
            this.repositorioDeProdutos = new RepositorioDeProdutos();
        }

        public ActionResult Index()
        {
            return View(repositorioDeProdutos.RecuperarProdutosDisponiveis());
        }

        public ActionResult DetalhesDoProduto(Guid id)
        {
            var produto = this.repositorioDeProdutos.BuscarPor(id);

            return View(produto);
        }
    }
}