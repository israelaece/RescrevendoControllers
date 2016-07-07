using ANC.Web.UI.Loja.Core.Eventos;
using ANC.Web.UI.Loja.Core.Infraestrutura;

namespace ANC.Web.UI.Loja.Util.EventHandlers
{
    public class Notificacao : IHandler<ClienteAdicionado>, IHandler<PedidoAdicionado>
    {
        private readonly INotifier notificador;

        public Notificacao(INotifier notificador)
        {
            this.notificador = notificador;
        }

        public void Handle(ClienteAdicionado message)
        {
            this.notificador.Send(
                "sistema@loja.com.br",
                message.Email,
                "Senha de Acesso",
                string.Format("Sua senha de acesso é: {0}", message.Senha));
        }

        public void Handle(PedidoAdicionado message)
        {
            var mensagem =
                string.Format(
                    "O seu pedido de número <b>{0}</b> no total de <b>{1:N2}</b> foi criado com sucesso em nossa base de dados, " +
                    "e aguarda a aprovação da operadora de cartão de crédito.",
                    message.PedidoId.ToString().ToUpper(),
                    message.Total);

            this.notificador.Send(
                "sistema@loja.com.br", message.EmailDoCliente, "Novo Pedido", mensagem);
        }
    }
}