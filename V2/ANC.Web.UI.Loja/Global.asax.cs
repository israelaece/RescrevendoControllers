using ANC.Web.UI.Loja.Core.Comandos;
using ANC.Web.UI.Loja.Core.Dominio.Repositorios;
using ANC.Web.UI.Loja.Core.Infraestrutura;
using ANC.Web.UI.Loja.Core.Repositorios;
using ANC.Web.UI.Loja.Models;
using ANC.Web.UI.Loja.Util;
using ANC.Web.UI.Loja.Util.EventHandlers;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using System.Web.Routing;
using MB = ANC.Web.UI.Loja.Util.ModelBinders;

namespace ANC.Web.UI.Loja
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Initialize();
        }

        private void Initialize()
        {
            var container = new UnityContainer();
            var bus = new InMemoryBus(new DependenciasDoDominio(container));

            container.RegisterInstance<IBus>(bus);
            container.RegisterInstance<IRepositorioDeClientes>(new RepositorioDeClientes(bus));
            container.RegisterInstance<IRepositorioDePedidos>(new RepositorioDePedidos(bus));
            container.RegisterInstance<IRepositorioDeProdutos>(new RepositorioDeProdutos());
            container.RegisterInstance<IDados>(new CacheLocal());
            container.RegisterInstance<INotifier>(new EmailNotifier());

            //Comandos
            bus.RegisterHandler<AdicionarClienteHandler>(); 
            bus.RegisterHandler<AdicionarPedidoHandler>();

            //Eventos
            bus.RegisterHandler<AtualizacaoDeCacheLocal>();
            bus.RegisterHandler<Notificacao>();
            bus.RegisterHandler<Autenticacao>();

            ModelBinders.Binders.Add(typeof(ProdutoDisponivel), new MB.Produto());
            DependencyResolver.SetResolver(new DependenciasDaWeb(container, DependencyResolver.Current));
        }
    }
}