using ANC.Web.UI.Loja.Comandos.Infraestrutura;
using ANC.Web.UI.Loja.Core.Comandos;
using ANC.Web.UI.Loja.Core.Repositorios.EmMemoria;

namespace ANC.Web.UI.Loja.App_Start
{
    public class CommandConfig
    {
        public static void RegisterCommands(ConstrutorDeControllersComDependencias dependencias)
        {
            var bus = new CommandBus();

            var repositorioDeClientes = new RepositorioDeClientes();
            var repositorioDePedidos = new RepositorioDePedidos();
            var repositorioDeProdutos = new RepositorioDeProdutos();

            bus.Register<AdicionarCliente>(new AdicionarClienteHandler(repositorioDeClientes).Handle);
            bus.Register<AdicionarPedido>(new AdicionarPedidoHandler(repositorioDeClientes, repositorioDePedidos, repositorioDeProdutos).Handle);

            dependencias.Add<ICommandSender>(bus);
        }
    }
}