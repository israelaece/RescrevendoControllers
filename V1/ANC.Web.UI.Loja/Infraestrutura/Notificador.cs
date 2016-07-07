using System.Net.Mail;

namespace ANC.Web.UI.Loja.Infraestrutura
{
    public interface INotificador
    {
        void Send(string de, string para, string assunto, string mensagem);
    }

    public class NotificadorViaEmail : INotificador
    {
        public void Send(string de, string para, string assunto, string mensagem)
        {
            using (var smtp = new SmtpClient())
                smtp.Send(new MailMessage(de, para, assunto, mensagem) { IsBodyHtml = true });
        }
    }
}