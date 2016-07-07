using System.Net.Mail;

namespace ANC.Web.UI.Loja.Core.Infraestrutura
{
    public interface INotifier
    {
        void Send(string from, string to, string subject, string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Send(string from, string to, string subject, string message)
        {
            using (var smtp = new SmtpClient())
                smtp.Send(new MailMessage(from, to, subject, message) { IsBodyHtml = true });
        }
    }
}