using ANC.Web.UI.Loja.Infraestrutura;
using ANC.Web.UI.Loja.Models;
using ANC.Web.UI.Loja.Repositorios;
using ANC.Web.UI.Loja.Util;
using ANC.Web.UI.Loja.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IRepositorioDeClientes repositorioDeClientes;
        private readonly IRepositorioDePedidos repositorioDePedidos;
        private readonly INotificador notificador;

        public ClientesController()
        {
            this.repositorioDeClientes = new RepositorioDeClientes();
            this.repositorioDePedidos = new RepositorioDePedidos();
            this.notificador = new NotificadorViaEmail();
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            cliente.Senha = GerarSenha();

            this.repositorioDeClientes.Adicionar(cliente);
            this.notificador.Send("sistema@loja.com.br", cliente.Email, "Senha de Acesso", cliente.Senha);

            GestorDeAcesso.Autenticar(cliente.Id);

            return RedirectToAction("Index", "Catalogo");
        }

        private static string GerarSenha()
        {
            return "P@$$w0rd";
        }

        public ActionResult Perfil()
        {
            var cliente = this.repositorioDeClientes.BuscarPor(this.ClienteId);
            var posicao = new PosicaoDoCliente()
            {
                Email = cliente.Email,
                Foto = cliente.Foto,
                Nome = cliente.Nome
            };

            var resumo =
                (
                    from p in this.repositorioDePedidos.BuscarPor(cliente)
                    group p by p.Cliente.Id into temp
                    select new
                    {
                        Qtde = temp.Count(),
                        Total = temp.Sum(p => p.Total),
                        UltimoPedido = temp.Max(p => p.Data)
                    }
                ).SingleOrDefault();

            if (resumo != null)
            {
                posicao.QuantidadeDePedidos = resumo.Qtde;
                posicao.TotalDosPedidos = resumo.Total;
                posicao.DataDoUltimoPedido = resumo.UltimoPedido;
            }

            return PartialView("Perfil", posicao);
        }
    }
}