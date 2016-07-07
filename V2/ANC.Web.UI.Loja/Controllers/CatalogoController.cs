using ANC.Web.UI.Loja.Models;
using ANC.Web.UI.Loja.Util;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Controllers
{
    public class CatalogoController : BaseController
    {
        private readonly IDados dados;

        public CatalogoController(IDados dados)
        {
            this.dados = dados;
        }

        public ActionResult Index()
        {
            return View(dados.RecuperarProdutosDisponiveis());
        }

        public ActionResult DetalhesDoProduto(ProdutoDisponivel id)
        {
            return View(id);
        }
    }
}