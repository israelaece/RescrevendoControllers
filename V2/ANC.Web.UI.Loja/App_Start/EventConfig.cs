using ANC.Web.UI.Loja.Core.Consultas;
using ANC.Web.UI.Loja.Core.Eventos;
using ANC.Web.UI.Loja.Core.Eventos.Infraestrutura;
using ANC.Web.UI.Loja.Core.Infraestrutura;

namespace ANC.Web.UI.Loja.App_Start
{
    public class EventConfig
    {
        public static void RegisterEvents(ConstrutorDeControllersComDependencias dependencias)
        {
            var notificador = new NotificadorViaEmail();
            var dataModelFacade = (IDataFacade)dependencias.GetService(typeof(IDataFacade));

            var bus = new EventBus();

            bus.Register<ClienteAdicionado>(new ReplicarClienteParaBaseDeLeitura(dataModelFacade).Handle);
            bus.Register<ClienteAdicionado>(new EnviarSenhaDeAcesso(notificador).Handle);
            bus.Register<ClienteAdicionado>(new AutenticarCliente().Handle);

            bus.Register<PedidoAdicionado>(new NotificarPedidoRealizado(notificador).Handle);
            bus.Register<PedidoAdicionado>(new ReplicarPedidoParaBaseDeLeitura(dataModelFacade).Handle);
            bus.Register<PedidoAdicionado>(new AtualizarEstoque(dataModelFacade).Handle);
            bus.Register<PedidoAdicionado>(new AtualizarPosicaoDoCliente(dataModelFacade).Handle);

            dependencias.Add<IEventPublisher>(bus);
        }
    }
}