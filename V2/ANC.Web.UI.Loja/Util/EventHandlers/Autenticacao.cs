using ANC.Web.UI.Loja.Core.Eventos;
using ANC.Web.UI.Loja.Core.Infraestrutura;

namespace ANC.Web.UI.Loja.Util.EventHandlers
{
    public class Autenticacao : IHandler<ClienteAdicionado>
    {
        public void Handle(ClienteAdicionado message)
        {
            GestorDeAcesso.Autenticar(message.Id);
        }
    }
}