using ANC.Web.UI.Loja.Core.Comandos;
using ANC.Web.UI.Loja.Core.Infraestrutura;
using ANC.Web.UI.Loja.Models;
using ANC.Web.UI.Loja.Util;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IDados dados;
        private readonly IBus bus;

        public ClientesController(IDados dados, IBus bus)
        {
            this.dados = dados;
            this.bus = bus;
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        #region Adicionar V1

        [HttpPost]
        public ActionResult Adicionar(AdicaoDeCliente formulario)
        {
            if (!ModelState.IsValid)
            {
                return View(formulario);
            }

            this.bus.Send(new AdicionarCliente()
            {
                Email = formulario.Email,
                Nome = formulario.Nome,
                Foto = formulario.Foto
            });

            return RedirectToAction("Index", "Catalogo");
        }

        #endregion

        #region Adicionar V2 - AR

        //[HttpPost]
        //public ActionResult Adicionar(AdicaoDeCliente formulario)
        //{
        //    return this.Command(
        //        new AdicionarCliente()
        //        {
        //            Email = formulario.Email,
        //            Nome = formulario.Nome,
        //            Foto = formulario.Foto
        //        },
        //        RedirectToAction("Index", "Catalogo"),
        //        View(formulario));
        //}

        #endregion

        public ActionResult Perfil()
        {
            var posicao = dados.RecuperarPosicaoDoCliente(this.ClienteId);

            return PartialView("Perfil", posicao);
        }
    }
}